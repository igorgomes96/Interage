using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.DTO
{
    public class UsuarioCredenciaisDTO
    {
        public UsuarioCredenciaisDTO()
        {
            Perfil = new PerfilDTO();
            EnderecoUsuario = new EnderecoDTO();
            Credenciais = new CredenciaisDTO();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public PerfilDTO Perfil { get; set; }
        public EnderecoDTO EnderecoUsuario { get; set; }
        public CredenciaisDTO Credenciais { get; set; }
    }
}
