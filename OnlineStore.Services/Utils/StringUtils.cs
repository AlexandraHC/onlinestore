﻿using System.Text;

namespace OnlineStore.Services.Utils
{
    public static class StringUtils
    {
        public static string Base64Encode(string text)
        {
            var textBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(textBytes);
        }
        public static string Base64Decode(string base64)
        {
            var base64Bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(base64Bytes);
        }
    }
}
