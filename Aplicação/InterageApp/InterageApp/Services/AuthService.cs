using InterageApp.Auth;
using InterageApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using InterageApp.Models;

namespace InterageApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICryptoService _cryptoService;

        public AuthService(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public Task<IPrincipal> Authenticate(string token)
        {
            
            string[] plainText = _cryptoService.Decrypt(token).Split(':');

            UserAuth user = new UserAuth
            {
                Email = plainText[0],
                CPF = plainText[1],
                NomePerfil = plainText[2],
                Validade = DateTime.Parse(plainText[3])
            };

            if (user.Validade > DateTime.Now)
                return null;

            IIdentity identity = new CustomIdentity(user, "Basic");
            IPrincipal p = new GenericPrincipal(identity, new[] { user.NomePerfil });

            return Task.FromResult(p);
        }

        public UserReturn Login(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Logout(string token)
        {
            throw new NotImplementedException();
        }
    }
}