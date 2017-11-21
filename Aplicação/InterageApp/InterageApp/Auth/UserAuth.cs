using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Auth
{
    public class UserAuth
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public int CodigoPerfil { get; set; }
        public string NomePerfil { get; set; }
    }
}