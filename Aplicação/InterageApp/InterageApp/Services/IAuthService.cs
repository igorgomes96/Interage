using InterageApp.Auth;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace InterageApp.Services
{
    public interface IAuthService
    {
        UserReturn Login(Usuario usuario);
        Task<IPrincipal> Authenticate(string token);
        void Logout(string token);
    }
}