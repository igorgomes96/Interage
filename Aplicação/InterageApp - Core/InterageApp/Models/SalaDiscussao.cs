using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class SalaDiscussao
    {
        public int Codigo { get; set; }
        public int CodAtividade { get; set; }
        public bool? Fechada { get; set; }
        public string EmailUsuarioExpectador { get; set; }

        public Atividade Atividade { get; set; }
        public Usuario UsuarioExpectador { get; set; }
    }
}
