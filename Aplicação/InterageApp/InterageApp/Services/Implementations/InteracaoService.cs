using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;

namespace InterageApp.Services.Implementations
{
    public class InteracaoService : IInteracaoService
    {
        private readonly IGenericRepository<int, Interacao, InteracaoDto> _interacaoRep;

        public InteracaoService(IGenericRepository<int, Interacao, InteracaoDto> interacaoRep)
        {
            _interacaoRep = interacaoRep;
        }

        public void EnviarMensagem(InteracaoDto interacao)
        {
            _interacaoRep.Save(interacao);
        }

        public ICollection<InteracaoDto> List(int codAtividade)
        {
            return _interacaoRep.Query(x => x.CodAtividade == codAtividade);
        }
    }
}