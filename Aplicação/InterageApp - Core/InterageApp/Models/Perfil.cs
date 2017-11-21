using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Codigo { get; set; }
        public string NomePerfil { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
