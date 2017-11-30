using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterageApp.Models
{
    [Table("Interacoes")]
    public class Interacao
    {

        public int CodSalaDiscussao { get; set; }
        public string Mensagem { get; set; }
        public int VotosPositivos { get; set; }
        public int VotosNegativos { get; set; }
    }
}