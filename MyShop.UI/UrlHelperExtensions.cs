using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.UI
{
    public static class UrlHelperExtensions
    {
        private const string WebRootBasePath = "wwwroot";

        public static string AddFingerPrint(this IUrlHelper urlHelper, string contentPath)
        {
            string url = urlHelper.Content(contentPath);
            var fileInfo = new FileInfo(WebRootBasePath + url);
            string fileHash = ComputeFileHash(fileInfo.OpenRead());           

            return $"{url}?v={fileHash}";
        }

        private static string ComputeFileHash(Stream fileStream)
        {
            using (SHA256 hasher = new SHA256Managed())
            using (fileStream)
            {
                byte[] hashBytes = hasher.ComputeHash(fileStream);

                var sb = new StringBuilder(hashBytes.Length * 2);

                foreach (byte hashByte in hashBytes)
                {
                    sb.AppendFormat("{0:x2}", hashByte);
                }

                return sb.ToString();
            }
        }
    }
}
