using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class Atividade
    {
        public Atividade()
        {
            ExpositoresAtividade = new HashSet<ExpositorAtividade>();
            SalasDiscussoes = new HashSet<SalaDiscussao>();
        }

        public int Codigo { get; set; }
        public int CodEvento { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime HorarioAtividade { get; set; }
        public string Endereco { get; set; }

        public Evento Evento { get; set; }
        public EnderecoAtividade EnderecoAtividade { get; set; }
        public ICollection<ExpositorAtividade> ExpositoresAtividade { get; set; }
        public ICollection<SalaDiscussao> SalasDiscussoes { get; set; }
    }
}
