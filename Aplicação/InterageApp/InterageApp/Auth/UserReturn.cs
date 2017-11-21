using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Auth
{
    public class UserReturn
    {
        public string Email { get; set; }
        public string CPF { get; set; }
        public string NomePerfil { get; set; }
        public DateTime Validade { get; set; }
        public string Token { get; set; }
    }
}