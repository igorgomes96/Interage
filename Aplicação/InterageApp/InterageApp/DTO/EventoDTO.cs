using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class EventoDTO
    {
        public EventoDTO()
        {

        }
        public EventoDTO (Evento e)
        {
            if (e == null) return;
            Codigo = e.Codigo;
            Nome = e.Nome;
            CodAreaInteresse = e.CodAreaInteresse;
            LocalizacaoLatitude = e.LocalizacaoLatitude;
            LocalizacaoLogitude = e.LocalizacaoLogitude;
            DataInicio = e.DataInicio;
            DataFim = e.DataFim;
            EmailUsuarioPromotor = e.EmailUsuarioPromotor;
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodAreaInteresse { get; set; }
        public Nullable<decimal> LocalizacaoLatitude { get; set; }
        public Nullable<decimal> LocalizacaoLogitude { get; set; }
        public System.DateTime DataInicio { get; set; }
        public System.DateTime DataFim { get; set; }
        public string EmailUsuarioPromotor { get; set; }
    }
}