using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTask2.Application.RestApiClient.Common;
using SeleniumTask2.Application.Interfaces;
using SeleniumTask2.Application.Constants;
using SeleniumTask2.Application.RequestBuilder;

namespace SeleniumTask2.Application.RestApiClient
{
    public class RestApiClient : IRestApiClient
    {
        readonly RestClient _client;

        public RestApiClient(string apiKey, string apiKeySecret)
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");

            _client = new RestClient(options)
            {
                Authenticator = new AppAuthenticator("https://content.dropboxapi.com", apiKey, apiKeySecret)
            };
        }

        public async Task<string> GetFile(string fileId)
        {
            var request = new RestRequest(RouteConstants.GetMetaDataUrl + $"/{fileId}");

            var response = await _client.GetAsync(request);
            return response.Content;

        }

        public async Task<string> UploadFile(string localFilePath, CancellationToken token)
        {
            var request = new UploadFileRequest(localFilePath);
            request.SetHeaders(); // can I add execution of these methods to constructor?
            request.SetBody();
            
            var response = new RestResponse();

            try
            {
                response = await _client.PostAsync(request.GetRequest(), token);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("The request was terminated");
            }

            return response.Content;
        }

        public async Task<string> DeleteFile(string filePath, CancellationToken token)
        {
            var request = new DeleteFileRequest(filePath);
            request.SetHeaders(); // can I add execution of these methods to constructor?
            request.SetBody();

            var response = new RestResponse();

            try
            {
                response = await _client.DeleteAsync(request.GetRequest(), token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("The request was terminated");
            }

            return response.Content;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

