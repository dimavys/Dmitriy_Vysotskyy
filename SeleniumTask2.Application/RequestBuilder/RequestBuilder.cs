using System;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumTask2.Application.RequestBuilder
{
	public static class RequestBuilder
	{
		public static RestRequest GetRequest (GetFileMetaDataRequest metaRequest)
		{
			var request = new RestRequest(Constants.RouteConstants.GetMetaDataUrl, Method.Post);
			request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = metaRequest.FilePath });
			return request;
        }
    }
}

