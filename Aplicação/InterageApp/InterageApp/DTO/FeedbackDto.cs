using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class FeedbackDto
    {
        public int Codigo { get; set; }
        public int CodEvento { get; set; }
        public string TipoFeedback { get; set; }
        public string FeedbackMensagem { get; set; }
        public string EmailUsuario { get; set; }
        public UsuarioDto Usuario { get; set; }
        public EventoDto Evento { get; set; }
    }
}