using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class UsuarioExpectadorDTO : UsuarioPadraoDTO
    {
        public UsuarioExpectadorDTO() { }
        public UsuarioExpectadorDTO (UsuarioExpectador u) : base(u.UsuarioPadrao)
        {
            if (u == null) return;
            PermiteInteragir = u.PermiteInteragir;
        }

        public UsuarioExpectador GetUsuarioExpectador()
        {
            return new UsuarioExpectador
            {
                CodUsuario = CodUsuario,
                CPF = CPF,
                PermiteInteragir = PermiteInteragir
            };
        }

        public Nullable<bool> PermiteInteragir { get; set; }
    }
}