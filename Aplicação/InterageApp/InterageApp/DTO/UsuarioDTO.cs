using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO() {
            Perfil = new PerfilDTO();
            EnderecoUsuario = new EnderecoDTO();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public PerfilDTO Perfil { get; set; }
        public EnderecoDTO EnderecoUsuario { get; set; }
    }
}