using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class PerfilDTO
    {
        public PerfilDTO() { }
        public PerfilDTO(Perfil p)
        {
            if (p == null) return;
            Codigo = p.Codigo;
            NomePerfil = p.NomePerfil;
        }
        public int Codigo { get; set; }
        public string NomePerfil { get; set; }
    }
}