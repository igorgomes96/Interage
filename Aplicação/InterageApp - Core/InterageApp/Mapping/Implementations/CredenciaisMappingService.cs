using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Implementations
{
    public class CredenciaisMappingService : IGenericMappingService<CredenciaisDTO, Credenciais>
    {
        public CredenciaisDTO Map(Credenciais entity)
        {
            return new CredenciaisDTO
            {
                Email = entity.Email,
                Senha = entity.Senha
            };
        }

        public Credenciais Map(CredenciaisDTO entity)
        {
            return new Credenciais
            {
                Email = entity.Email,
                Senha = entity.Senha
            }; ;
        }

        public IEnumerable<CredenciaisDTO> Map(IEnumerable<Credenciais> entities)
        {
            return entities.Select(x => Map(x));
        }

        public IEnumerable<Credenciais> Map(IEnumerable<CredenciaisDTO> entities)
        {
            return entities.Select(x => Map(x));
        }
    }
}
