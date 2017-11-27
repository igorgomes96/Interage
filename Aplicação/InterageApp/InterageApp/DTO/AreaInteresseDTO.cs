using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class AreaInteresseDto
    {
        public int Codigo { get; set; }

        [StringLength(80, ErrorMessage = "Campo de 'Interesse' pode ter no máximo 80 caracateres!")]
        [Required(ErrorMessage = "Campo de 'Interesse' é obrigatório!")]
        public string Interesse { get; set; }
    }
}