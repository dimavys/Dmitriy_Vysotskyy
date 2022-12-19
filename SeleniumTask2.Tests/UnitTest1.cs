using System.Security.Cryptography;
using SeleniumTask2.Application.RestApiClient;

namespace SeleniumTask2.Tests;

public class Tests
{
    private RestApiClient _restClient = new RestApiClient();

    [OneTimeSetUp]
    public void Setup()
    {
    }

    [Test, Order(1)]
    public async Task TestUpload()
    {
        var exists = File.Exists("Usings.cs");

        var result = await _restClient.UploadFile("files/file.txt");

        Assert.AreEqual(true, result.is_downloadable);
    }

    //[Test, Order(2)]
    //public async Task TestMetadata()
    //{
    //    var result = await _restClient.GetFileMetadata("/file.txt");

    //    Assert.AreEqual("file.txt", result.name);
    //}

    //[Test, Order(3)]
    //public async Task TestDelete()
    //{
    //    var result = await _restClient.DeleteFile("/file.txt");

    //    Assert.AreEqual(false, result.is_downloadable);
    //}

    [OneTimeTearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }

}