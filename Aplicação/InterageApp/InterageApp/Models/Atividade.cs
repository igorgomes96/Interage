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

        [Required(ErrorMessage = "O Código do Evento deve ser informado!")]
        public int CodEvento { get; set; }

        [Required(ErrorMessage = "O nome da atividade precisa ser informado!")]
        [StringLength(20, ErrorMessage = "O nome da atividade pode ter no máximo 20 caracteres!")]
        public string Nome { get; set; }

        [StringLength(150, ErrorMessage = "A descrição da atividade pode ter no máximo 150 caracteres!")]
        [Required(ErrorMessage = "A descrição da atividade deve ser informada!")]
        public string DescricaoAtividade { get; set; }

        [Required(ErrorMessage = "O horário da atividade precisa ser informado!")]
        public DateTime HorarioAtividade { get; set; }

        [StringLength(80, ErrorMessage = "O email do expositor pode ter no máximo 80 caracteres!")]
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
