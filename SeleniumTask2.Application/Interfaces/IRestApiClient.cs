using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTask2.Application.Interfaces
{
	public interface IRestApiClient
	{
        Task<T> GetFile<T>(string user);
        Task<string> UploadFile(string localFilePath, CancellationToken token);
    }
}

