using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class Evento
    {
        public Evento()
        {
            Atividades = new HashSet<Atividade>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodAreaInteresse { get; set; }
        public decimal? LocalizacaoLatitude { get; set; }
        public decimal? LocalizacaoLogitude { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string EmailUsuarioPromotor { get; set; }

        public AreaInteresse AreaInteresse { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Atividade> Atividades { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
