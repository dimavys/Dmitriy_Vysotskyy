using System;
using System.IO;
using RestSharp;
namespace Dmitriy_Vysotskyy
{
	public class RestApiHelper
	{
		private RestClient _restClient;

		private RestRequest _restRequest;

		private string _baseUrl = "";

		public RestClient SetUrl(string resourceUrl)
		{
			var url = Path.Combine(_baseUrl, resourceUrl);
			return new RestClient(url);
		}

		public RestRequest CreatePostRequest(string jsonString)
		{
			_restRequest = new RestRequest(Method.Post);
			_restRequest.AddHeader("Accept", "application/json");
			_restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
			return _restRequest;
		}
	}
}

