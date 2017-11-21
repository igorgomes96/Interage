using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class AreaInteresse
    {
        public AreaInteresse()
        {
            Eventos = new HashSet<Evento>();
            UsuariosInteresses = new HashSet<UsuarioInteresse>();
        }

        public int Codigo { get; set; }
        public string Interesse { get; set; }

        public ICollection<Evento> Eventos { get; set; }
        public ICollection<UsuarioInteresse> UsuariosInteresses { get; set; }
    }
}
