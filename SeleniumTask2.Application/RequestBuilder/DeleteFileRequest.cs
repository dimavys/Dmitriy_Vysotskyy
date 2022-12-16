using System;
using RestSharp;
using SeleniumTask2.Application.Constants;

namespace SeleniumTask2.Application.RequestBuilder
{
	public class DeleteFileRequest : RestApiHelper
	{
		private RestRequest _restRequest;

		private string _filePath;

		public DeleteFileRequest(string filePath)
		{
			_filePath = filePath;
			_restRequest = new RestRequest();
		}

		public override void SetHeaders()
		{
			_restRequest.AddHeader("Authorization", RouteConstants.TokenType + " " + RouteConstants.GeneratedToken);
			_restRequest.AddHeader("Dropbox-API-Arg", RouteConstants.DropBoxApiArgValue);
			_restRequest.AddHeader("Content-Type", RouteConstants.ContentTypeValue);
		}

        public override void SetBody()
        {
            _restRequest.AddParameter("path", _filePath, ParameterType.RequestBody);
        }

        public override RestRequest GetRequest()
        {
			return _restRequest;
        }
    }
}

