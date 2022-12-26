using System.Security.Cryptography;
using SeleniumTask2.Application.RestApiClient;

namespace SeleniumTask2.Tests;

public class TestScenario
{
    private RestApiClient _restClient;

    private readonly string _localFilePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "files/file.txt");

    [OneTimeSetUp]
    public void Setup()
    {
        _restClient = new RestApiClient();
    }

    [Test, Order(1)]
    public async Task TestUpload()
    {
        var response = await _restClient.UploadFile(_localFilePath);

        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        Assert.AreEqual(true, response.Data.is_downloadable);
    }

    [Test, Order(2)]
    public async Task TestMetadata()
    {
        var response = await _restClient.GetFileMetadata("/file.txt");

        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        Assert.AreEqual("file.txt", response.Data.name);
    }

    [Test, Order(3)]
    public async Task TestDelete()
    {
        var response = await _restClient.DeleteFile("/file.txt");

        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        Assert.AreEqual(true, response.Data.metadata.is_downloadable);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _restClient.Dispose();
    }

}