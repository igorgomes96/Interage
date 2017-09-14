using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class UsuarioPromotorDTO : UsuarioPadraoDTO
    {
        public UsuarioPromotorDTO() { }
        public UsuarioPromotorDTO(UsuarioPromotor u) : base(u.UsuarioPadrao) 
        {
            Endereco = u.Endereco;
        }

        public UsuarioPromotor GetUsuarioPromotor ()
        {
            return new UsuarioPromotor
            {
                CodUsuario = CodUsuario,
                CPF = CPF,
                Endereco = Endereco
            };
        }
        public string Endereco { get; set; }
    }
}