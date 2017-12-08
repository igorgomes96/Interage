using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class InteracaoDto
    {

        public int CodAtividade { get; set; }
        public string Mensagem { get; set; }
        public string EmailUsuario { get; set; }
        public DateTime Hora { get; set; }

    }
}