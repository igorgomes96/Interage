using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class EventoDTO
    {
        public EventoDTO (Evento e)
        {
            if (e == null) return;
            Codigo = e.Codigo;
            Nome = e.Nome;
            CodUsuario = e.CodUsuario;
            CPFUsuarioPromotor = e.CPFUsuarioPromotor;
            CodAreaInteresse = e.CodAreaInteresse;
            LocalizacaoLatitude = e.LocalizacaoLatitude;
            LocalizacaoLogitude = e.LocalizacaoLogitude;
            DataInicio = e.DataInicio;
            DataFim = e.DataFim;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodUsuario { get; set; }
        public string CPFUsuarioPromotor { get; set; }
        public Nullable<int> CodAreaInteresse { get; set; }
        public Nullable<decimal> LocalizacaoLatitude { get; set; }
        public Nullable<decimal> LocalizacaoLogitude { get; set; }
        public Nullable<System.DateTime> DataInicio { get; set; }
        public Nullable<System.DateTime> DataFim { get; set; }
    }
}