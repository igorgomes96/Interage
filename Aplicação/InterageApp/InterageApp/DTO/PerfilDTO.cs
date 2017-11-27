using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class PerfilDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome do perfil precisa ser informado!")]
        [StringLength(80, ErrorMessage = "O nome do perfil pode ter no máximo 80 caracteres!")]
        public string NomePerfil { get; set; }
    }
}