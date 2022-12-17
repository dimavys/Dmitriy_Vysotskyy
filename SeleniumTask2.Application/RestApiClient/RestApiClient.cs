using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTask2.Application.RestApiClient.Common;
using SeleniumTask2.Application.Interfaces;
using SeleniumTask2.Application.Constants;
using SeleniumTask2.Application.RequestBuilder;
using System.Net.Mime;
using SeleniumTask2.Application.Responses;
using System.Text.Json.Serialization;
using Json.Net;
using System.Security.Principal;

namespace SeleniumTask2.Application.RestApiClient
{
    public class RestApiClient 
    {
        readonly RestClient _client;

        public RestApiClient()
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");

            _client = new RestClient(options)
            {

            };

            _client.AddDefaultHeader("Authorization", RouteConstants.GeneratedToken);
        }

        public async Task<FileMetaData> GetFileMetadata(string filePath, CancellationToken token)
        {
            var request = RequestBuilder.RequestBuilder.GetRequest(new GetFileMetaDataRequest(filePath));

            var response = new RestResponse();

            try
            {
                response = await _client.ExecutePostAsync(request, token);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("The request was terminated");
            }

            return new JsonConverter.DeserializeObject<FileMetaData>(response.Content);
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

