using Serenity.CrossCutting.Contracts.Security;
using System.Security.Cryptography;
using System.Text;

namespace Serenity.CrossCutting.Security
{
    public class Criptografia : ICriptografia
    {
        public string GETMD5(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("X2");
            }

            return result;
        }
    }
}
