using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping
{
    public class UsuarioMapper : IMapper<Usuario, UsuarioDto>
    {
        private readonly IMapper<EnderecoUsuario, EnderecoDto> _enderecoMapper;
        private readonly IMapper<AreaInteresse, AreaInteresseDto> _interesseMapper;
        private readonly IMapper<Perfil, PerfilDto> _perfilMapper;

        public UsuarioMapper(IMapper<EnderecoUsuario, EnderecoDto> enderecoMapper,
            IMapper<AreaInteresse, AreaInteresseDto> interesseMapper,
            IMapper<Perfil, PerfilDto> perfilMapper)
        {
            _enderecoMapper = enderecoMapper ?? throw new ArgumentNullException(nameof(enderecoMapper));
            _interesseMapper = interesseMapper ?? throw new ArgumentNullException(nameof(interesseMapper));
            _perfilMapper = perfilMapper ?? throw new ArgumentNullException(nameof(perfilMapper));
        }

        public UsuarioDto Map(Usuario source)
        {
            return new UsuarioDto
            {
                Nome = source.Nome,
                Email = source.Email,
                CPF = source.CPF,
                CodigoPerfil = source.CodigoPerfil,
                Endereco = _enderecoMapper.Map(source.EnderecoUsuario),
                Perfil = _perfilMapper.Map(source.Perfil),
                AreasInteresse = _interesseMapper.Map(source.AreasInteresse)
            };
        }

        public Usuario Map(UsuarioDto destination)
        {
            return new Usuario
            {
                Nome = destination.Nome,
                Email = destination.Email,
                CPF = destination.CPF,
                CodigoPerfil = destination.CodigoPerfil
            };
        }

        public ICollection<UsuarioDto> Map(ICollection<Usuario> source)
        {
            return source.Select(x => Map(x)).ToList();
        }

        public ICollection<Usuario> Map(ICollection<UsuarioDto> destination)
        {
            return destination.Select(x => Map(x)).ToList();
        }
    }
}