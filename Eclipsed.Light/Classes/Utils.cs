using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace honeypot.Classes
{
    public static class Utils
    {
        public static string CalculateSha1(string text) => CalculateSha1(Encoding.UTF8.GetBytes(text));

        public static string CalculateSha1(byte[] b)
        {
            using (var sha = SHA1.Create())
            {
                var hash = sha.ComputeHash(b);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
