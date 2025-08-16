using Authentication.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.Validator
{
    public class CryptoService : ICryptoService
    {
        public string ComputeHash(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyHash(string input, string hash)
        {
            var computed = ComputeHash(input);
            return computed == hash;
        }
    }
}