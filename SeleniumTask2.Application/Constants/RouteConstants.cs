using System;
namespace SeleniumTask2.Application.Constants
{
	public static class RouteConstants
	{
		public static readonly string BaseUrl = "https://api.dropboxapi.com/";

		public static readonly string GetMetaDataUrl = "https://api.dropboxapi.com/2/files/get_metadata";

		public static readonly string TokenType = "Bearer";

		public static readonly string GeneratedToken = "sl.BVIAGWwmlcnXz81M1okRCJQQa6NosTIv8_k8_euLjP18eyuATVVn8IXSA08hG8BeyDCmRCEGQYxOrygJKY-bT5fp6jSM-Ea6v4I_f_Tnkd2YHyG1ixfvVQl7TH79BpxrVoCqO_gsOlyl";


		public static readonly string DropBoxApiArgValue = "{\"mode\":\"add\",\"path\":\"/TestFolder/file.txt\"}";

		public static readonly string ContentTypeValue = "application/octet-stream";
    }
}

