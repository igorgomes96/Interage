using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using InterageApp.Repository.Interfaces;
using InterageApp.Models;
using InterageApp.Exceptions;

namespace InterageApp.Services.Implementations
{
    public class AtividadesService : IAtividadesService
    {
        private readonly IGenericRepository<int, Atividade, AtividadeDto> _atividadeRep;

        public AtividadesService(IGenericRepository<int, Atividade, AtividadeDto> atividadeRep)
        {
            _atividadeRep = atividadeRep;
        }

        public AtividadeDto Buscar(int id)
        {
            return _atividadeRep.Find(id);
        }

        public AtividadeDto CriarNova(AtividadeDto atividade)
        {
            try { 
                return _atividadeRep.Save(atividade);
            } catch (ConflitoException<Atividade>)
            {
                return _atividadeRep.Update(atividade);
            }
        }

        public AtividadeDto ExcluirAtividade(int id)
        {
            return _atividadeRep.Delete(id);
        }

    }
}