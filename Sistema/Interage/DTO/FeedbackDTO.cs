using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class FeedbackDTO
    {
        public FeedbackDTO() { }
        public FeedbackDTO(Feedback f)
        {
            if (f == null) return;
            CodEvento = f.CodEvento;
            CodUsuario = f.CodUsuario;
            TipoFeedback = f.TipoFeedback;
            MensagemFeedback = f.MensagemFeedback;
        }
        public int CodEvento { get; set; }
        public int CodUsuario { get; set; }
        public string TipoFeedback { get; set; }
        public string MensagemFeedback { get; set; }
    }
}