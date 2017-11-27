using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class PerfilMapper : ISingleMapper<Perfil, PerfilDto>
    {
        public PerfilDto Map(Perfil source)
        {
            return source == null ? null : new PerfilDto
            {
                Codigo = source.Codigo,
                NomePerfil = source.NomePerfil
            };
        }

        public Perfil Map(PerfilDto destination)
        {
            return destination == null ? null : new Perfil
            {
                Codigo = destination.Codigo,
                NomePerfil = destination.NomePerfil
            };
        }
    }
}