using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{
    
    [Table("AreasInteresse")]
    public partial class AreaInteresse
    {
        public AreaInteresse()
        {
            Eventos = new HashSet<Evento>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Index("interesse_unq", IsUnique = true)]
        [StringLength(80, ErrorMessage = "Campo de 'Interesse' pode ter no máximo 80 caracateres!")]
        [Required(ErrorMessage = "Campo de 'Interesse' é obrigatório!")]
        public string Interesse { get; set; }
    
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Usuario> UsuariosInteressados { get; set; }
    }
}
