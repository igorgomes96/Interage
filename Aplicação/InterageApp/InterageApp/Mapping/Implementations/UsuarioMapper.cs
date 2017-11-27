using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class UsuarioMapper : ISingleMapper<Usuario, UsuarioDto>
    {
        private readonly IMapper<Endereco, EnderecoDto> _enderecoMapper;
        private readonly IMapper<AreaInteresse, AreaInteresseDto> _interesseMapper;
        private readonly IMapper<Perfil, PerfilDto> _perfilMapper;

        public UsuarioMapper(IMapper<Endereco, EnderecoDto> enderecoMapper,
            IMapper<AreaInteresse, AreaInteresseDto> interesseMapper,
            IMapper<Perfil, PerfilDto> perfilMapper)
        {
            _enderecoMapper = enderecoMapper ?? throw new ArgumentNullException(nameof(enderecoMapper));
            _interesseMapper = interesseMapper ?? throw new ArgumentNullException(nameof(interesseMapper));
            _perfilMapper = perfilMapper ?? throw new ArgumentNullException(nameof(perfilMapper));
        }

        public UsuarioDto Map(Usuario source)
        {
            return source == null ? null : new UsuarioDto
            {
                Nome = source.Nome,
                Email = source.Email,
                CPF = source.CPF,
                CodigoPerfil = source.CodigoPerfil,
                CodEndereco = source.CodEndereco,
                Endereco = _enderecoMapper.Map(source.Endereco),
                Perfil = _perfilMapper.Map(source.Perfil),
                AreasInteresse = _interesseMapper.Map(source.AreasInteresse)
            };
        }

        public Usuario Map(UsuarioDto destination)
        {
            return destination == null ? null : new Usuario
            {
                Nome = destination.Nome,
                Email = destination.Email,
                CPF = destination.CPF,
                CodigoPerfil = destination.CodigoPerfil,
                CodEndereco = destination.CodEndereco
            };
        }

    }
}