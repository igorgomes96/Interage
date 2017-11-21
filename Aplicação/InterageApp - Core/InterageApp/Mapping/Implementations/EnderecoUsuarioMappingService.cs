using InterageApp.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterageApp.DTO;
using InterageApp.Models;

namespace InterageApp.Mapping.Implementations
{
    public class EnderecoUsuarioMappingService : IEnderecoUsuarioMappingService
    {
        public EnderecoUsuario Map(UsuarioDTO usuario)
        {
            return new EnderecoUsuario
            {
                EmailUsuario = usuario.Email,
                Rua = usuario.EnderecoUsuario.Rua,
                Complemento = usuario.EnderecoUsuario.Complemento,
                Bairro = usuario.EnderecoUsuario.Bairro,
                CEP = usuario.EnderecoUsuario.CEP,
                Cidade = usuario.EnderecoUsuario.Cidade,
                UF = usuario.EnderecoUsuario.UF
            };
        }
    }
}
