using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Implementations
{
    public class PerfilMappingService : IGenericMappingService<PerfilDTO, Perfil>
    {
        public PerfilDTO Map(Perfil entity)
        {
            return new PerfilDTO
            {
                Codigo = entity.Codigo,
                NomePerfil = entity.NomePerfil
            };
        }

        public Perfil Map(PerfilDTO entity)
        {
            return new Perfil
            {
                Codigo = entity.Codigo,
                NomePerfil = entity.NomePerfil
            };
        }

        public IEnumerable<PerfilDTO> Map(IEnumerable<Perfil> entities)
        {
            return entities.Select(x => Map(x));
        }

        public IEnumerable<Perfil> Map(IEnumerable<PerfilDTO> entities)
        {
            return entities.Select(x => Map(x));
        }
    }
}
