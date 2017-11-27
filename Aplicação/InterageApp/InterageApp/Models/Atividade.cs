using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    [Table("Atividades")]
    public partial class Atividade
    {
        public Atividade()
        {
            SalasDiscussoes = new HashSet<SalaDiscussao>();
            Participantes = new HashSet<Usuario>();
        }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O C�digo do Evento deve ser informado!")]
        public int CodEvento { get; set; }

        [StringLength(150, ErrorMessage = "A descri��o da atividade pode ter no m�ximo 150 caracteres!")]
        [Required(ErrorMessage = "A descri��o da atividade deve ser informada!")]
        public string DescricaoAtividade { get; set; }

        [Required(ErrorMessage = "O hor�rio da atividade precisa ser informado!")]
        public DateTime HorarioAtividade { get; set; }

        [Required(ErrorMessage = "O endere�o da atividade precisa ser informado!")]
        [StringLength(255, ErrorMessage = "O endere�o da atividade pode ter no m�ximo 255 caracteres!")]
        public string Endereco { get; set; }

        [StringLength(80, ErrorMessage = "O email do expositor pode ter no m�ximo 80 caracteres!")]
        [Required(ErrorMessage = "O email do expositor da atividade precisa ser informado!")]
        public string EmailExpositor { get; set; }
    

        [ForeignKey("CodEvento")]
        public virtual Evento Evento { get; set; }

        [ForeignKey("EmailExpositor")]
        public virtual Usuario Expositor { get; set; }

        public virtual ICollection<SalaDiscussao> SalasDiscussoes { get; set; }
        public virtual ICollection<Usuario> Participantes { get; set; }
    }
}
