using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class UsuarioPadraoDTO : UsuarioDTO
    {
        public UsuarioPadraoDTO() { }
        public UsuarioPadraoDTO(UsuarioPadrao u) : base (u.Usuario)
        {
            if (u == null) return;
            CodUsuario = u.CodUsuario;
            CPF = u.CPF;
        }

        public UsuarioPadrao GetUsuarioPadrao()
        {
            return new UsuarioPadrao
            {
                CodUsuario = CodUsuario,
                CPF = CPF
            };
        }

        public string CPF { get; set; }
    }
}