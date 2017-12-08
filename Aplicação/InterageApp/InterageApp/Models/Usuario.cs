using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{

    [Table("Usuarios")]
    public partial class Usuario
    {
        public Usuario()
        {
            AtividadesExpostas = new HashSet<Atividade>();
            EventosPromovidos = new HashSet<Evento>();
            Feedbacks = new HashSet<Feedback>();
            EventosInscritos = new HashSet<Evento>();
            AreasInteresse = new HashSet<AreaInteresse>();
        }

        [Key]
        [Required(ErrorMessage = "O email do usuário precisa ser informadao!")]
        [StringLength(50, ErrorMessage = "O email pode ter no máximo 50 caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome do usuário precisa ser informadao!")]
        [StringLength(80, ErrorMessage = "O nome pode ter no máximo 80 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do usuário precisa ser informadao!")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres!", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O perfil do usuário precisa ser informadao!")]
        public int CodigoPerfil { get; set; }

        [Required(ErrorMessage = "O senha do usuário precisa ser informadao!")]
        [StringLength(25, ErrorMessage = "O senha deve ter entre 8 e 25 caracteres!", MinimumLength = 8)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O endereço do usuário precisa ser informadao!")]
        public int CodEndereco { get; set; }

        [ForeignKey("CodigoPerfil")]
        public virtual Perfil Perfil { get; set; }
        [ForeignKey("CodEndereco")]
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Atividade> AtividadesExpostas { get; set; }
        public virtual ICollection<Evento> EventosPromovidos { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Evento> EventosInscritos { get; set; }
        public virtual ICollection<AreaInteresse> AreasInteresse { get; set; }
    }
}
