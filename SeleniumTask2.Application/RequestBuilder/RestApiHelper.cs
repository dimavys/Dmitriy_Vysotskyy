using System;
using RestSharp;

namespace SeleniumTask2.Application.RequestBuilder
{
	public abstract class RestApiHelper
	{
        public abstract void SetHeaders();

        public abstract void SetBody();

		public abstract RestRequest GetRequest();
	}
}

