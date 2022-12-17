using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumTask2.Application.RestApiClient;

namespace SeleniumTask2.Tests
{
    public class Tests
    {
        private readonly RestApiClient _restClient = new RestApiClient();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
           var result = await _restClient.GetFileMetadata("file.txt");

            Assert.Pass();
        }
    }
}
