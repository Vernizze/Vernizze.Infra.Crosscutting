using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        private const int TAIL_SIZE = 8192;

        public static string GetMd5(this string value)
        {
            var sBuilder = new StringBuilder();
            var md5Hash = MD5.Create();

            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string ReadTail(this string value, string filename, int size = TAIL_SIZE)
        {
            var result = string.Empty;

            using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fs.Seek(size * -1, SeekOrigin.End);

                byte[] bytes = new byte[size];

                fs.Read(bytes, 0, size);

                string s = Encoding.UTF8.GetString(bytes);

                result = s;
            }

            return result;
        }

        public static string ReadTail(this string value, int size = TAIL_SIZE)
        {
            var result = string.Empty;

            var byteArray = Encoding.UTF8.GetBytes(value);

            using (Stream fs = new MemoryStream(byteArray))
            {
                fs.Seek(size * -1, SeekOrigin.End);

                byte[] bytes = new byte[size];

                fs.Read(bytes, 0, size);

                string s = Encoding.UTF8.GetString(bytes);

                result = s;
            }

            return result;
        }

        public static string RemoverCaracteresEspeciais(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
                result = Regex.Replace(value, @"[^0-9a-zA-Z]+", string.Empty);

            return result;
        }

        public static bool IsBoolean(this string value)
        {
            var valid_values = new List<string> { "0", "1" };

            var result = (!string.IsNullOrEmpty(value)) && (valid_values.Contains(value) || bool.TryParse(value, out bool res_parse));

            return result;
        }

        public static bool IsNumeric2(this string value)
        {
            return float.TryParse(value, out var x);
        }

        public static bool IsNotNumeric(this string value)
        {
            return !IsNumeric2(value);
        }

        public static string Trunc(this string value, int lenght)
        {
            if (lenght < 0)
                lenght = 0;

            return value.PadLeft(lenght, ' ').Substring(0, lenght).Trim();
        }
    }
}