using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    [Table("SalasDiscussao")]
    public partial class SalaDiscussao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "A atividade precisa ser informada!")]
        public int CodAtividade { get; set; }

        [Required(ErrorMessage = "Precisa ser informado se a sala est� aberta ou fechada!")]
        public bool Fechada { get; set; }

        [Required(ErrorMessage = "� preciso informar o email do usu�rio!")]
        [StringLength(50, ErrorMessage = "O email do usu�rio pode ter no m�ximo 50 caracteres!")]
        public string EmailUsuarioExpectador { get; set; }
    
        [ForeignKey("CodAtividade")]
        public virtual Atividade Atividade { get; set; }
        [ForeignKey("EmailUsuarioExpectador")]
        public virtual Usuario Usuario { get; set; }

        //public virtual ICollection<Interacao> Interacoes { get; set; }
    }
}
