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

		public static readonly string GeneratedToken = "sl.BVsvJpN4lqNo5MMfo_sDdB9K2iRYZVm7SCB-Tf_yQDil9m0tWGXDWSPqiLO_-9_eYDoZlfV059e94Z72L_Opr7bqDmnVqTOTXBbbfMacKaZtRUGqxqRMnRlscI-vY5B9oFBj5K8QjEjB";
    }
}

