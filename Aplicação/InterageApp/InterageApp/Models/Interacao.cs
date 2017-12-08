using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterageApp.Models
{
    [Table("SalasDiscussoes")]
    public class Interacao
    {

        public int Id { get; set; }
        public int CodAtividade { get; set; }
        public string Mensagem { get; set; }
        [StringLength(50)]
        public string EmailUsuario { get; set; }
        public DateTime Hora { get; set; }

        [ForeignKey("CodAtividade")]
        public virtual Atividade Atividade { get; set; }
        [ForeignKey("EmailUsuario")]
        public virtual Usuario Usuario { get; set; }

    }
}