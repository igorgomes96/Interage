using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IAreasInteresseService
    {
        /// <summary>
        /// Lista todas as áreas de interesses cadastradas.
        /// </summary>
        /// <returns></returns>
        ICollection<AreaInteresseDto> Listar();

        /// <summary>
        /// Cadastra uma nova área de interesse
        /// </summary>
        /// <param name="areaInteresse"></param>
        /// <returns></returns>
        AreaInteresseDto CriarNova(AreaInteresseDto areaInteresse);

        /// <summary>
        /// Lista as áreas de interesse
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        AreaInteresseDto Excluir(int codigo);
    }
}
