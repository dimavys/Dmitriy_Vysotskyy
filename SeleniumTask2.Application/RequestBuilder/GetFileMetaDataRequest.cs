using System;
using RestSharp;

namespace SeleniumTask2.Application.RequestBuilder
{
	public class GetFileMetaDataRequest
	{
		public string FilePath { get; }

		public GetFileMetaDataRequest(string filePath)
		{
			FilePath = filePath;
		}
	}
}

