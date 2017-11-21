using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class ExpositorAtividade
    {
        public int CodAtividade { get; set; }
        public string EmailUsuarioExpositor { get; set; }

        public Atividade Atividade { get; set; }
        public Usuario UsuarioExpositor { get; set; }
    }
}
