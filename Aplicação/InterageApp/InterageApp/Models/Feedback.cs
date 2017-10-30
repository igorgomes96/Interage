using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    public partial class Feedback
    {
        public int CodEvento { get; set; }
        public string TipoFeedback { get; set; }
        [Column("Feedback")]
        public string MensagemFeedback { get; set; }
        public string EmailUsuario { get; set; }
        public int Codigo { get; set; }

        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
