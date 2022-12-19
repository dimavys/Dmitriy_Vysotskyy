using System;
namespace SeleniumTask2.Application.Constants
{
	public static class RouteConstants
	{
		public static readonly string BaseUrl = "https://api.dropboxapi.com/";

		public static readonly string GetMetaDataUrl = "https://api.dropboxapi.com/2/files/get_metadata";

		public static readonly string DeleteFileUrl = "https://api.dropboxapi.com/2/files/delete_v2";

		public static readonly string UploadFileUrl = "https://content.dropboxapi.com/2/files/upload";

        public static readonly string TokenType = "Bearer";

		public static readonly string GeneratedToken = "sl.BVNVEQ2C4ZP6pQGtrVklJVpa1vm_AHJrrQn2_FY56KBJeVlNw5_NWjBHmiEy0m3U_sPt--LNFTwUj0FWX_GyC4zmVkFLnQlpH9TsV0bJGECLGE8oli7lVNwXcTMqfw2TeRM8JRx5CxW4";

    }
}

