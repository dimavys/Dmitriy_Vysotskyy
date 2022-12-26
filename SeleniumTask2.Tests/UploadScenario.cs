using System;
using SeleniumTas

namespace SeleniumTask2.Tests
{
    public class UploadScenario
    {
        private RestApiClient _restClient;

        private readonly string _localFilePath = "/Users/mac/Desktop/file.txt"; // insert your own text file path here

        [SetUp]
        public void Setup()
        {
            _restClient = new RestApiClient();
        }

        [Test]
        public async Task UploadFile_TxtFile_ShouldUploadSuccessfully()
        {
            var result = await _restClient.UploadFile(_localFilePath);

            Assert.AreEqual(true, result.is_downloadable);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _restClient.DeleteFile("/file.txt");

            _restClient.Dispose();
        }
    }
}

