using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAZ.Application.Storage.Extensions
{
	public static class FormFileExtensions
	{
		public static bool IsImage(this IFormFile formFile)
		{
			return formFile.ContentType.Contains("image/");
		}

        public static string GetFileExtension(this IFormFile formFile)
        {
            if (formFile.ContentType == null)
                return null;

            string[] parts = formFile.ContentType.Split('/');
            string lastPart = parts[parts.Length - 1];
            switch (lastPart)
            {
                case "pjpeg":
                    lastPart = "jpg";
                    break;
                case "x-png":
                    lastPart = "png";
                    break;
                case "x-icon":
                    lastPart = "ico";
                    break;
            }
            return lastPart;
        }
    }
}
