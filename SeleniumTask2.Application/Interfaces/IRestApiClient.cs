using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTask2.Application.Interfaces
{
	public interface IRestApiClient
	{
        Task<string> GetFileMetadata(string user);
        Task<string> UploadFile(string localFilePath, CancellationToken token);
    }
}

