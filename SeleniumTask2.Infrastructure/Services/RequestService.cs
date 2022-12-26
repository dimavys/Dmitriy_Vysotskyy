using System;
using RestSharp;
using SeleniumTask2.Infrastructure.Constants;

namespace SeleniumTask2.Infrastructure.Services
{
	public static class RequestService
	{
        public static RestRequest BuildGetRequest(string filePath)
		{
            var request = new RequestBuilder.RequestBuilder()
               .SetUrl(RouteConstants.GetMetaDataUrl)
               .SetHeader("Content-Type", "application/json")
               .SetBody<object>(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = filePath })
               .Build();

            return request;
        }

        public static RestRequest BuildPostRequest(string localFilePath)
		{
            var request = new RequestBuilder.RequestBuilder()
                .SetUrl(RouteConstants.UploadFileUrl)
                .SetHeader("Dropbox-API-Arg", "{\"path\":\"/file.txt\"}")
                .SetHeader("Content-Type", "application/octet-stream")
                .SetFile(localFilePath)
                .Build();

            return request;
        }

        public static RestRequest BuildDeleteRequest(string filePath)
		{
            var request = new RequestBuilder.RequestBuilder()
                .SetUrl(RouteConstants.DeleteFileUrl)
                .SetHeader("Content-Type", "application/json")
                .SetBody<object>(new { path = filePath })
                .Build();

            return request;
        }

    }
}

