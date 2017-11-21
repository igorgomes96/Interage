using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class UsuarioInteresse
    {
        public int CodInteresse { get; set; }
        public string EmailUsuario { get; set; }

        public AreaInteresse AreaInteresse { get; set; }
        public Usuario Usuario { get; set; }
    }
}
