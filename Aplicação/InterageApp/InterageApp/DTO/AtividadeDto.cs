using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class AtividadeDto
    {
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

        public EventoDto Evento { get; set; }
        public UsuarioDto Expositor { get; set; }
    }
}