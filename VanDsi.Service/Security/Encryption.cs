using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VanDsi.Service.Security
{
    internal static class Encryption
    {
        internal static string UserPassword(string data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var shaData = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(data)));
            var data1 = shaData.Substring(0, 7);
            var data2 = shaData.Substring(7, 7);
            var data3 = shaData.Substring(14, 7);
            var data4 = shaData.Substring(21, 7);
            return data3 + data2 + data4 + data1;
        }
    }
}
