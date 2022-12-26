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

		public static readonly string GeneratedToken = "sl.BVaoSTRE6LqU4vNQ63hH5143VaaZtDQxiQ1ZC6RKJaWQOjV0H8mADcwa4fRrcIOPKOZ9qr_6F38kti3wgv-hyJyVRm1c1PnLKw-bncwoJfy4qOvICXx80pVeAuJWvDxTT267_P_Cj6of";
    }
}

