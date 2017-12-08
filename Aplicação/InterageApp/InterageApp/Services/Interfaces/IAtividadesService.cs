using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IAtividadesService
    {
        /// <summary>
        /// Busca uma atividade pelo Código.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AtividadeDto Buscar(int id);

        /// <summary>
        /// Cadastra uma nova ativiadde.
        /// </summary>
        /// <param name="atividade"></param>
        /// <returns></returns>
        AtividadeDto CriarNova(AtividadeDto atividade);

        /// <summary>
        /// Excluir a atividade pelo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AtividadeDto ExcluirAtividade(int id);

    }
}
