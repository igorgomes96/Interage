using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class AtividadeMapper : ISingleMapper<Atividade, AtividadeDto>
    {

        private readonly IMapper<Evento, EventoDto> _eventoMapper;
        private readonly IMapper<Usuario, UsuarioDto> _usuarioMapper;

        public AtividadeMapper(IMapper<Evento, EventoDto> eventoMapper,
            IMapper<Usuario, UsuarioDto> usuarioMapper)
        {
            _eventoMapper = eventoMapper;
            _usuarioMapper = usuarioMapper;

        }
        public AtividadeDto Map(Atividade source)
        {
            return source == null ? null : new AtividadeDto
            {
                Codigo = source.Codigo,
                CodEvento = source.CodEvento,
                DescricaoAtividade = source.DescricaoAtividade,
                HorarioAtividade = source.HorarioAtividade,
                Endereco = source.Endereco,
                EmailExpositor = source.EmailExpositor,
                Evento = _eventoMapper.Map(source.Evento),
                Expositor = _usuarioMapper.Map(source.Expositor)
            };
        }

        public Atividade Map(AtividadeDto destination)
        {
            return destination == null ? null : new Atividade
            {
                Codigo = destination.Codigo,
                CodEvento = destination.CodEvento,
                DescricaoAtividade = destination.DescricaoAtividade,
                HorarioAtividade = destination.HorarioAtividade,
                Endereco = destination.Endereco,
                EmailExpositor = destination.EmailExpositor
            };
        }
    }
}