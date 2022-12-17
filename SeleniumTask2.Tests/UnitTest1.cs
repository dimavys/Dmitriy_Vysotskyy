using NUnit.Framework;
using SeleniumTask2.Application.RestApiClient;

namespace SeleniumTask2.Tests
{
    public class Tests
    {
        private readonly RestApiClient _restClient = new RestApiClient("uv5pvmctdrfr6ri", "czff2v6uz87y4e6");

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
           var result = _restClient.GetFile<byte[]>("file.txt");

            Assert.Pass();
        }
    }
}
