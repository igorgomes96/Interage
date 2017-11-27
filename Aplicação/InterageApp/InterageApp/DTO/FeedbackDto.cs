using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class FeedbackDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O evento precisa ser informado!")]
        public int CodEvento { get; set; }

        [Required(ErrorMessage = "O tipo do feedback precisa ser informado!")]
        [StringLength(50, ErrorMessage = "O tipo de feedback pode ter no máximo 50 caracteres!")]
        public string TipoFeedback { get; set; }

        [Required(ErrorMessage = "Informe o Feedback!")]
        [StringLength(4000, ErrorMessage = "O feedback pode ter no máximo 4000 caracteres!")]
        public string FeedbackMensagem { get; set; }

        [Required(ErrorMessage = "O usuário precisa ser informado!")]
        [StringLength(50, ErrorMessage = "O email do usuário pode ter no máximo 50 caracteres!")]
        public string EmailUsuario { get; set; }


        public UsuarioDto Usuario { get; set; }
        public EventoDto Evento { get; set; }
    }
}