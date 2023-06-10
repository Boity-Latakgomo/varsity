using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Service.Helpers
{
    public static class Utils
    {
        public static bool IsImage(IFormFile file)
        {
            return (file.ContentType.ToLower() != "image/jpg" &&
                    file.ContentType.ToLower() != "image/jpeg" &&
                    file.ContentType.ToLower() != "image/pjpeg" &&
                    file.ContentType.ToLower() != "image/gif" &&
                    file.ContentType.ToLower() != "image/x-png" &&
                    file.ContentType.ToLower() != "video/mp4");
            // Alternatively, you can also check the file's magic numbers (file signature).
            // For example, to check for PNG files:
            // var headerBytes = new byte[8];
            // using var stream = file.OpenReadStream();
            // stream.Read(headerBytes, 0, 8);
            // var header = Encoding.UTF8.GetString(headerBytes);
            // return header.StartsWith("\x89PNG\r\n\x1a\n");
        }
    }
}