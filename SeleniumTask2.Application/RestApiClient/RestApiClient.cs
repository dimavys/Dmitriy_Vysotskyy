using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTask2.Application.RestApiClient.Common;
using SeleniumTask2.Application.Interfaces;
using SeleniumTask2.Application.Constants;
using SeleniumTask2.Application.RequestBuilder;
using SeleniumTask2.Application.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Principal;
using System.IO;

namespace SeleniumTask2.Application.RestApiClient
{
    public class RestApiClient 
    {
        private readonly RestClient _client;

        public RestApiClient()
        {
            var options = new RestClientOptions("https://content.dropboxapi.com/2");

            _client = new RestClient(options)
            {

            };

            _client.AddDefaultHeader("Authorization", RouteConstants.TokenType+ " " + RouteConstants.GeneratedToken);
        }

        public async Task<FileMetaData> GetFileMetadata(string filePath)
        {
            var request = new RequestBuilder.RequestBuilder()
                .SetUrl(RouteConstants.GetMetaDataUrl)
                .SetHeader("application/json")
                .SetBody<object>(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = filePath })
                .Build();
                
            var response = await _client.ExecutePostAsync(request);
            
            return JsonSerializer.Deserialize<FileMetaData>(response.Content);
        }

        public async Task<FileMetaData> DeleteFile(string filePath)
        {
            var request = new RequestBuilder.RequestBuilder()
                .SetUrl(RouteConstants.DeleteFileUrl)
                .SetHeader("application/json")
                .SetBody<object>(new { path = filePath })
                .Build();

            var response = await _client.ExecutePostAsync(request);

            return JsonSerializer.Deserialize<FileMetaData>(response.Content);
        }

        public async Task<FilePostResponse> UploadFile(string localFilePath)
        {
            var request = new RequestBuilder.RequestBuilder()
                .SetUrl(RouteConstants.UploadFileUrl)
                .SetHeader("application/octet-stream")
                .SetBody<object>(new { autorename = false, mode = "add", mute = false, path = "/file.txt", strict_conflict = false })
                .Build();

            byte[] fileData = File.ReadAllBytes(localFilePath);

            request.AddParameter("file", fileData, ParameterType.RequestBody);

            var response = await _client.ExecutePostAsync(request);

            return JsonSerializer.Deserialize<FilePostResponse>(response.Content);
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

