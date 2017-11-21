using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public int CodigoPerfil { get; set; }
        public EnderecoDto Endereco { get; set; }
        public PerfilDto Perfil { get; set; }
        public ICollection<AreaInteresseDto> AreasInteresse { get; set; }
    }
}