using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterageApp.Models
{

    [Table("Enderecos")]
    public partial class Endereco
    {
        public Endereco() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome da rua precisa ser informado!")]
        [StringLength(100, ErrorMessage = "O nome da rua pode ter no m�ximo 100 caracteres!")]
        public string Rua { get; set; }

        [StringLength(100, ErrorMessage = "O complemento do endere�o pode ter no m�ximo 100 caracteres!")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O nome do bairro precisa ser informado!")]
        [StringLength(50, ErrorMessage = "O nome do bairro pode ter no m�ximo 50 caracteres!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O nome da cidade precisa ser informado!")]
        [StringLength(50, ErrorMessage = "O nome da cidade pode ter no m�ximo 50 caracteres!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A UF precisa ser informada!")]
        [StringLength(2, ErrorMessage = "A UF deve ter 2 caracteres!", MinimumLength = 2)]
        public string UF { get; set; }

        [Required(ErrorMessage = "O CEP precisa ser informado!")]
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres!", MinimumLength = 8)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O n�mero precisa ser informado!")]
        public int Numero { get; set; }
        
    }
}
