using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class UsuarioCredenciaisMapper : ISingleMapper<Usuario, UsuarioCredenciaisDto>
    {
        private readonly IMapper<Endereco, EnderecoDto> _enderecoMapper;
        private readonly IMapper<Perfil, PerfilDto> _perfilMapper;

        public UsuarioCredenciaisMapper(IMapper<Endereco, EnderecoDto> enderecoMapper,
            IMapper<Perfil, PerfilDto> perfilMapper)
        {
            _enderecoMapper = enderecoMapper ?? throw new ArgumentNullException(nameof(enderecoMapper));
            _perfilMapper = perfilMapper ?? throw new ArgumentNullException(nameof(perfilMapper));
        }

        public UsuarioCredenciaisDto Map(Usuario source)
        {
            return source == null ? null : new UsuarioCredenciaisDto
            {
                Nome = source.Nome,
                Email = source.Email,
                CPF = source.CPF,
                CodigoPerfil = source.CodigoPerfil,
                CodEndereco = source.CodEndereco,
                Endereco = _enderecoMapper.Map(source.Endereco),
                Perfil = _perfilMapper.Map(source.Perfil),
                Senha = source.Senha
            };
        }

        public Usuario Map(UsuarioCredenciaisDto destination)
        {
            return destination == null ? null : new Usuario
            {
                Nome = destination.Nome,
                Email = destination.Email,
                CPF = destination.CPF,
                CodigoPerfil = destination.CodigoPerfil,
                CodEndereco = destination.CodEndereco,
                Senha = destination.Senha
            };
        }

    }
}