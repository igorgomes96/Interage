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
    public class AreasInteresseService : IAreasInteresseService
    {
        private readonly IGenericRepository<int, AreaInteresse, AreaInteresseDto> _interesseRep;

        public AreasInteresseService(IGenericRepository<int, AreaInteresse, AreaInteresseDto> interesseRep)
        {
            _interesseRep = interesseRep;
        }


        public AreaInteresseDto CriarNova(AreaInteresseDto areaInteresse)
        {
            return _interesseRep.Save(areaInteresse);
        }

        public AreaInteresseDto Excluir(int codigo)
        {
            return _interesseRep.Delete(codigo);
        }

        public ICollection<AreaInteresseDto> Listar()
        {
            return _interesseRep.List();
        }
    }
}