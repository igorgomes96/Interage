using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InterageApp.Services
{
    public class CryptoService : ICryptoService
    {

        static byte[] s_aditionalEntropy = { 3, 6, 3, 2, 9 };

        public string Decrypt(string key)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(key), s_aditionalEntropy, DataProtectionScope.CurrentUser));
        }

        public string Encrypt(string plain)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(plain), s_aditionalEntropy, DataProtectionScope.CurrentUser));
        }
    }
}