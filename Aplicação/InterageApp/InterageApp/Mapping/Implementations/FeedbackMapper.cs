using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class FeedbackMapper : ISingleMapper<Feedback, FeedbackDto>
    {
        private readonly IMapper<Usuario, UsuarioDto> _usuarioMapper;
        private readonly IMapper<Evento, EventoDto> _eventoMapper;

        public FeedbackMapper(IMapper<Evento, EventoDto> eventoMapper, IMapper<Usuario, UsuarioDto> usuarioMapper)
        {
            _eventoMapper = eventoMapper;
            _usuarioMapper = usuarioMapper;

        }

        public FeedbackDto Map(Feedback source)
        {
            return source == null ? null : new FeedbackDto
            {
                Codigo = source.Codigo,
                CodEvento = source.CodEvento,
                TipoFeedback = source.TipoFeedback,
                FeedbackMensagem = source.FeedbackMensagem,
                EmailUsuario = source.EmailUsuario,
                Usuario = _usuarioMapper.Map(source.Usuario),
                Evento = _eventoMapper.Map(source.Evento)
            };
        }

        public Feedback Map(FeedbackDto destination)
        {
            return destination == null ? null : new Feedback
            {
                Codigo = destination.Codigo,
                CodEvento = destination.CodEvento,
                TipoFeedback = destination.TipoFeedback,
                FeedbackMensagem = destination.FeedbackMensagem,
                EmailUsuario = destination.EmailUsuario,
                Usuario = _usuarioMapper.Map(destination.Usuario),
                Evento = _eventoMapper.Map(destination.Evento)
            };
        }
    }
}