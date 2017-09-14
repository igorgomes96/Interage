using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO() { }

        public UsuarioDTO (Usuario u)
        {
            if (u == null) return;
            CodUsuario = u.CodUsuario;
            Nome = u.Nome;
            Senha = u.Senha;
            Email = u.Email;
        }

        public Usuario GetUsuario()
        {
            return new Usuario
            {
                CodUsuario = CodUsuario,
                Nome = Nome,
                Senha = Senha,
                Email = Email
            };
        }
        public int CodUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}