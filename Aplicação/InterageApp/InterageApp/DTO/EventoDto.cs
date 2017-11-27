using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class EventoDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int CodAreaInteresse { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string EmailUsuarioPromotor { get; set; }
        public int CodEndereco { get; set; }

        public AreaInteresseDto AreaInteresse { get; set; }
        public EnderecoDto Endereco { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}