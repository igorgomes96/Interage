using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping
{
    public class PerfilMapper : IMapper<Perfil, PerfilDto>
    {
        public PerfilDto Map(Perfil source)
        {
            return new PerfilDto
            {
                Codigo = source.Codigo,
                NomePerfil = source.NomePerfil
            };
        }

        public Perfil Map(PerfilDto destination)
        {
            return new Perfil
            {
                Codigo = destination.Codigo,
                NomePerfil = destination.NomePerfil
            };
        }

        public ICollection<PerfilDto> Map(ICollection<Perfil> source)
        {
            return source.Select(x => Map(x)).ToList();
        }

        public ICollection<Perfil> Map(ICollection<PerfilDto> destination)
        {
            return destination.Select(x => Map(x)).ToList();
        }
    }
}