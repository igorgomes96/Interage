using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class UsuarioExpositorDTO : UsuarioPadraoDTO
    {
        public UsuarioExpositorDTO() { }
        public UsuarioExpositorDTO (UsuarioExpositor u) : base(u.UsuarioPadrao)
        {
        }
        public UsuarioExpectador GetUsuarioExpectador()
        {
            return new UsuarioExpectador
            {
                CodUsuario = CodUsuario,
                CPF = CPF
            };
        }
    }
}