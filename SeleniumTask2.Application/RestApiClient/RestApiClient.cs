using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTask2.Application.RestApiClient.Common;
using SeleniumTask2.Application.Interfaces;
using SeleniumTask2.Application.Constants;
using SeleniumTask2.Application.RequestBuilder;
using System.Net.Mime;

namespace SeleniumTask2.Application.RestApiClient
{
    public class RestApiClient : IRestApiClient
    {
        readonly RestClient _client;

        public RestApiClient()
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");

            _client = new RestClient(options)
            {
            };

            _client.AddDefaultHeader("Authorization", "Bearer sl.BVLq7o9FmVyh3vq1b0UvTSR5VQJZTOJs9TvBuUVgHf_Wx2YirB9rp21nZAnmxvg7ZNY-MZzqPYquwcU96pxRvaUSryb9igSKeHLkYAaSkvZDpHleYuXHvJI4mlUp6k71rpx_nwNHdYqo");
        }

        public async Task<string> GetFileMetadata(string fileId)
        {
            var request = new RestRequest(RouteConstants.GetMetaDataUrl);

            request.AddHeader("Authorization", "Basic dXY1cHZtY3RkcmZyNnJpOmN6ZmYydjZ1ejg3eTRlNg==");
            request.AddHeader("Content-Type", "application/json");
            //var json = "{ \"include_deleted\": \"false\", \"include_has_explicit_shared_members\": \"false\", \"include_media_info\": \"false\", \"path\": \"/file.txt\"}";
            //request.AddStringBody(json, DataFormat.Json);

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { include_deleted = "false", include_has_explicit_shared_members = "false", include_media_info = "false", path = "/file.txt" });

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

