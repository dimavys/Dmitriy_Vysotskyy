using System;
namespace SeleniumTask2.Infrastructure.Constants
{
	public static class RouteConstants
	{
		public static readonly string BaseUrl = "https://api.dropboxapi.com/";

		public static readonly string GetMetaDataUrl = "https://api.dropboxapi.com/2/files/get_metadata";

		public static readonly string DeleteFileUrl = "https://api.dropboxapi.com/2/files/delete_v2";

		public static readonly string UploadFileUrl = "https://content.dropboxapi.com/2/files/upload";

        public static readonly string TokenType = "Bearer";
		public static readonly string GeneratedToken = "sl.BVuhx79-z5QOaNNRqYFjVe6Y3FwzkwDIyvvLtqozWKobfH3BwlGmrSmmgX_MigMi_5c0wtTtN7iTSsyC2uqi41ZcfFPVpNTWG-SCww6Cyxa0dOV-WyMdTufdQEDvGc7X7sPANWlPeTU9";
    }
}

