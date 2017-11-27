using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class AtividadeDto
    {
        public int Codigo { get; set; }
        public int CodEvento { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime HorarioAtividade { get; set; }
        public string Endereco { get; set; }

        public EventoDto Evento { get; set; }
    }
}