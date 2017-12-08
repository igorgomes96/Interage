using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    [Table("Eventos")]
    public partial class Evento
    {
        public Evento()
        {
            Atividades = new HashSet<Atividade>();
            Feedbacks = new HashSet<Feedback>();
            Participantes = new HashSet<Usuario>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome do evento precisa ser informado!")]
        [StringLength(80, ErrorMessage = "O nome do evento pode ter no m�ximo 80 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Uma descri��o para o evento precisa ser informado!")]
        [StringLength(255, ErrorMessage = "A descri��o do evento pode ter no m�ximo 255 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A �rea de interesse do evento precisa ser informada!")]
        public int CodAreaInteresse { get; set; }

        [Required(ErrorMessage = "A data de in�cio do evento precisa ser informada!")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de encerramento do evento precisa ser informada!")]
        public DateTime DataFim { get; set; }

        [StringLength(80, ErrorMessage = "O email do promotor pode ter no m�ximo 80 caracteres!")]
        [Required(ErrorMessage = "O email do promotor do evento precisa ser informado!")]
        public string EmailUsuarioPromotor { get; set; }

        [Required(ErrorMessage = "O endere�o do evento precisa ser informado!")]
        public int CodEndereco { get; set; }
    
        [ForeignKey("CodAreaInteresse")]
        public virtual AreaInteresse AreaInteresse { get; set; }
        [ForeignKey("CodEndereco")]
        public virtual Endereco Endereco { get; set; }
        [ForeignKey("EmailUsuarioPromotor")]
        public virtual Usuario Promotor { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Usuario> Participantes { get; set; }
    }
}
