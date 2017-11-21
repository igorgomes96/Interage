using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Implementations
{
    public class UsuarioMappingService : IGenericMappingService<UsuarioDTO, Usuario>
    {
        private readonly IGenericMappingService<PerfilDTO, Perfil> _perfilMap;
        private readonly IEnderecoUsuarioMappingService _enderecoMap;

        public UsuarioMappingService(IGenericMappingService<PerfilDTO, Perfil> perfilMap, IEnderecoUsuarioMappingService enderecoMap)
        {
            _perfilMap = perfilMap;
            _enderecoMap = enderecoMap;
        }

        public UsuarioDTO Map(Usuario entity)
        {
            UsuarioDTO retorno = new UsuarioDTO
            {
                Nome = entity.Nome,
                CPF = entity.CPF,
                Email = entity.Email,
                Perfil = _perfilMap.Map(entity.Perfil)
            };
            if (entity.EnderecoUsuario != null)
            {
                retorno.EnderecoUsuario = new EnderecoDTO
                {
                    Rua = entity.EnderecoUsuario.Rua,
                    Complemento = entity.EnderecoUsuario.Complemento,
                    Bairro = entity.EnderecoUsuario.Bairro,
                    Cidade = entity.EnderecoUsuario.Cidade,
                    UF = entity.EnderecoUsuario.UF,
                    CEP = entity.EnderecoUsuario.CEP
                };
            }
            return retorno;
        }

        public Usuario Map(UsuarioDTO entity)
        {
            return new Usuario
            {
                Nome = entity.Nome,
                CPF = entity.CPF,
                Email = entity.Email,
                CodigoPerfil = entity.Perfil.Codigo
            };
        }


        public IEnumerable<UsuarioDTO> Map(IEnumerable<Usuario> entities)
        {
            return entities.Select(x => Map(x));
        }

        public IEnumerable<Usuario> Map(IEnumerable<UsuarioDTO> entities)
        {
            return entities.Select(x => Map(x));
        }
    }
}
