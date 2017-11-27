using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class EventoMapper : ISingleMapper<Evento, EventoDto>
    {
        public readonly IMapper<AreaInteresse, AreaInteresseDto> _interesseMapper;
        public readonly IMapper<Endereco, EnderecoDto> _enderecoMapper;
        public readonly IMapper<Usuario, UsuarioDto> _usuarioMapper;

        public EventoMapper(IMapper<AreaInteresse, AreaInteresseDto> interesseMapper,
            IMapper<Endereco, EnderecoDto> enderecoMapper,
            IMapper<Usuario, UsuarioDto> usuarioMapper)
        {
            _interesseMapper = interesseMapper;
            _enderecoMapper = enderecoMapper;
            _usuarioMapper = usuarioMapper;
        }

        public EventoDto Map(Evento source)
        {
            return source == null ? null : new EventoDto { 
                Codigo = source.Codigo,
                Nome = source.Nome,
                CodAreaInteresse = source.CodAreaInteresse,
                DataInicio = source.DataInicio,
                DataFim = source.DataFim,
                EmailUsuarioPromotor = source.EmailUsuarioPromotor,
                CodEndereco = source.CodEndereco,
                AreaInteresse = _interesseMapper.Map(source.AreaInteresse),
                Endereco = _enderecoMapper.Map(source.Endereco),
                Usuario = _usuarioMapper.Map(source.Usuario)
            };
        }

        public Evento Map(EventoDto destination)
        {
            return destination == null ? null : new Evento
            {
                Codigo = destination.Codigo,
                Nome = destination.Nome,
                CodAreaInteresse = destination.CodAreaInteresse,
                DataInicio = destination.DataInicio,
                DataFim = destination.DataFim,
                EmailUsuarioPromotor = destination.EmailUsuarioPromotor,
                CodEndereco = destination.CodEndereco
            };
        }
    }
}