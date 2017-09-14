using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class SalaDiscussaoDTO
    {
        public SalaDiscussaoDTO() { }

        public SalaDiscussaoDTO(SalaDiscussao s)
        {
            if (s == null) return;
            Codigo = s.Codigo;
            CodAtividade = s.CodAtividade;
            CodExpectador = s.CodExpectador;
            CPFExpectador = s.CPFExpectador;
            Fechada = s.Fechada;
        }
        public int Codigo { get; set; }
        public int CodAtividade { get; set; }
        public int CodExpectador { get; set; }
        public string CPFExpectador { get; set; }
        public Nullable<bool> Fechada { get; set; }
    }
}