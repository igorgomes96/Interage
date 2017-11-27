using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class UsuarioCredenciaisDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public int CodigoPerfil { get; set; }
        public int CodEndereco { get; set; }
        public string Senha { get; set; }
        public EnderecoDto Endereco { get; set; }
        public PerfilDto Perfil { get; set; }
    }
}