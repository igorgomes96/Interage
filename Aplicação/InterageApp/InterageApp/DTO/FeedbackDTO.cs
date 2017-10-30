using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class FeedbackDTO
    {
        public FeedbackDTO() { }
        public FeedbackDTO(Feedback f)
        {
            if (f == null) return;
            CodEvento = f.CodEvento;
            EmailUsuario = f.EmailUsuario;
            TipoFeedback = f.TipoFeedback;
            MensagemFeedback = f.MensagemFeedback;
        }
        public int CodEvento { get; set; }
        public string EmailUsuario { get; set; }
        public string TipoFeedback { get; set; }
        public string MensagemFeedback { get; set; }
    }
}