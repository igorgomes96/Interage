using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class AtividadeDTO
    {
        public AtividadeDTO (Atividade a)
        {
            if (a == null) return;
            Codigo = a.Codigo;
            CodEvento = a.CodEvento;
            DescricaoAtividade = a.DescricaoAtividade;
            HorarioAtividade = a.HorarioAtividade;
            Endereco = a.Endereco;
        }
        public int Codigo { get; set; }
        public int CodEvento { get; set; }
        public string DescricaoAtividade { get; set; }
        public System.DateTime HorarioAtividade { get; set; }
        public string Endereco { get; set; }
    }
}