using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEMY.Constants
{
    public class UploadSettings
    {
        public const int MaxFileSize = 2 * 1024 * 1024;

        public static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png"
        };
    }
}