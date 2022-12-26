using System;
using RestSharp;
using System.Threading;
using System.Threading.Tasks;
using SeleniumTask2.Application.RestApiClient.Common;
using SeleniumTask2.Application.Constants;
using SeleniumTask2.Application.RequestBuilder;
using SeleniumTask2.Application.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Principal;
using System.IO;
using System.Reflection.PortableExecutable;
using SeleniumTask2.Application.Services;
using SeleniumTask2.Infrastructure.Responses;

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

            _client.AddDefaultHeader("Authorization", RouteConstants.TokenType + " " + RouteConstants.GeneratedToken);
        }

        public async Task<RestResponse<FileMetaData>> GetFileMetadata(string filePath) 
        {
            var request = RequestService.BuildGetRequest(filePath);
                
            var response = await _client.ExecutePostAsync<FileMetaData>(request);

            return response;
        }

        public async Task<RestResponse<DeleteFileMetaData>> DeleteFile(string filePath)
        {
            var request = RequestService.BuildDeleteRequest(filePath);

            var response = await _client.ExecutePostAsync<DeleteFileMetaData>(request);

            return response;
        }

        public async Task<RestResponse<FileMetaData>> UploadFile(string localFilePath)
        {
            var request = RequestService.BuildPostRequest(localFilePath);

            var response = await _client.ExecutePostAsync<FileMetaData>(request);

            return response;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

