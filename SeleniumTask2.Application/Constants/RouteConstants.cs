using System;
namespace SeleniumTask2.Application.Constants
{
	public static class RouteConstants
	{
		public static readonly string BaseUrl = "https://api.dropboxapi.com/";

		public static readonly string GetMetaDataUrl = "https://api.dropboxapi.com/2/files/get_metadata";

		public static readonly string TokenType = "Bearer";

		public static readonly string GeneratedToken = "sl.BVAHwRNTN-pLdXkQG1swUfjQHn6nc3juRAs2HT9bPj46MgO8dOAVtikD_rX6VFxZrrtTdhDN-cFOUTydXg6M_koRQVU8p0zS_OQTF29mIIjm9EmLV3F0qN5BXSPAEWz_e9Xqx2j7nYpy";


		public static readonly string DropBoxApiArgValue = "{\"mode\":\"add\",\"path\":\"/TestFolder/file.txt\"}";

		public static readonly string ContentTypeValue = "application/octet-stream";
    }
}

