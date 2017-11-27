using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    [Table("Perfis")]
    public partial class Perfil
    {
        public Perfil() { }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Index("nome_perfil_unq", IsUnique = true)]
        [Required(ErrorMessage = "O nome do perfil precisa ser informado!")]
        [StringLength(80, ErrorMessage = "O nome do perfil pode ter no máximo 80 caracteres!")]
        public string NomePerfil { get; set; }

    }
}
