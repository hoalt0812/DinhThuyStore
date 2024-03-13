using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib
{
    public class Common
    {
        public static string Md5Endcoding(string password)
        {
            return
                BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password)))
                    .Replace("-", string.Empty);
        }
    }
}
