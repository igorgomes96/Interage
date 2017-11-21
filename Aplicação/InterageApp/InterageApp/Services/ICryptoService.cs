using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services
{
    public interface ICryptoService
    {
        string Encrypt(string plain);
        string Decrypt(string key);
    }
}
