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
                Nome = source.Nome,
                DescricaoAtividade = source.DescricaoAtividade,
                HorarioAtividade = source.HorarioAtividade,
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
                Nome = destination.Nome,
                DescricaoAtividade = destination.DescricaoAtividade,
                HorarioAtividade = destination.HorarioAtividade,
                EmailExpositor = destination.EmailExpositor
            };
        }
    }
}