using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class SalaDiscussaoDTO
    {
        public SalaDiscussaoDTO() { }

        public SalaDiscussaoDTO(SalaDiscussao s)
        {
            if (s == null) return;
            Codigo = s.Codigo;
            CodAtividade = s.CodAtividade;
            EmailUsuarioExpectador = s.EmailUsuarioExpectador;
            Fechada = s.Fechada;
        }
        public int Codigo { get; set; }
        public int CodAtividade { get; set; }
        public int CodExpectador { get; set; }
        public string EmailUsuarioExpectador { get; set; }
        public Nullable<bool> Fechada { get; set; }
    }
}