using System;
using System.IO;
using RestSharp;
using SeleniumTask2.Application.Constants;
using static System.Net.Mime.MediaTypeNames;

namespace SeleniumTask2.Application.RequestBuilder
{
	public class RequestBuilder
	{
		private RestRequest _restRequest;

		public RequestBuilder SetUrl(string url)
		{
			_restRequest = new RestRequest(url, Method.Post);
			return this;
        }

		public RequestBuilder SetHeader(string contentType)
		{
			_restRequest.AddHeader("Content-Type", contentType);
            return this;
        }

        public RequestBuilder SetHeader(string key, string value)
		{
            _restRequest.AddHeader(key, value);
            return this;
        }


        public RequestBuilder SetBody<T>(T body) where T : class
		{
			_restRequest.AddJsonBody(body);
            return this;
        }

        public RequestBuilder SetFile(string filePath)
		{
            byte[] fileData = File.ReadAllBytes(filePath);
            _restRequest.AddParameter("application/octet-stream", fileData, ParameterType.RequestBody);
            return this;
		}

        public RestRequest Build()
		{
			return _restRequest;
		}
    }
}

