using System;
using System.IO;
using RestSharp;
using SeleniumTask2.Application.Constants;

namespace SeleniumTask2.Application.RequestBuilder
{
	public class UploadFileRequest : RestApiHelper
	{
		private RestRequest _restRequest;

        private string _filePath;

        public UploadFileRequest(string filePath)
        {
            _filePath = filePath;
            _restRequest = new RestRequest();
        }

		public override void SetHeaders()
		{
			_restRequest.AddHeader("Authorization", RouteConstants.TokenType + " " + RouteConstants.GeneratedToken);
			_restRequest.AddHeader("Dropbox-API-Arg", RouteConstants.DropBoxApiArgValue);
			_restRequest.AddHeader("Content-Type", RouteConstants.ContentTypeValue);

            FileInfo fileInfo = new FileInfo(_filePath);
            long fileLength = fileInfo.Length;
            _restRequest.AddHeader("Content-Length", fileLength.ToString());
        }

        public override void SetBody()
        {
            byte[] fileData = File.ReadAllBytes(_filePath);
            _restRequest.AddParameter("file", fileData, ParameterType.RequestBody);
        }

        public override RestRequest GetRequest()
        {
            return _restRequest;
        }
    }
}

