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

		public static readonly string GeneratedToken = "sl.BVvHxIfKcWsbcVG0-NJHNIol3494Cwjsj2ISd6Yr-7GvBHPH4qsMd76irTngCQv1Cp8rsANi00wwxPJ2-nLoZ21PUT0SKWw4bxACP79tJ_iOzauDtIeYnNAeoLXoTBSgKI2lhXc3p7mH";
    }
}

