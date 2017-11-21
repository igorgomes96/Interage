using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterageApp.Exceptions;

namespace InterageApp.Repository
{
    public interface IRepository<Entity, DTO, Chave> where Entity: class where DTO: class
    {
        /// <summary>
        /// Retorna uma lista com todos os registros do banco.
        /// </summary>
        /// <returns>Uma lista com todos os registros do banco</returns>
        ICollection<DTO> Read();

        /// <summary>
        /// Procura um registro pela chave.
        /// </summary>
        /// <param name="chave">Chave do registro procurado</param>
        /// <returns>Registro encontrado</returns>
        /// <exception cref="NotFoundException">Não foi encontrado nenhum registro com a chave informada.</exception>
        DTO Read(Chave chave);

        /// <summary>
        /// Insere ou atualiza um registro no banco de dados.
        /// </summary>
        /// <param name="resource">Objeto Entitdade (Registro)</param>
        /// <returns>Registro salvo</returns>
        DTO Save(DTO resource);

        /// <summary>
        /// Procura um registro pela chave, e exclui.
        /// </summary>
        /// <param name="chave">Chave do registro procurado</param>
        /// <returns>Registro excluído.</returns>
        /// <exception cref="NotFoundException">Não foi encontrado nenhum registro com a chave informada.</exception>
        DTO Delete(Chave chave);

        /// <summary>
        /// Faz uma consulta ao banco
        /// </summary>
        /// <param name="predicate">Query</param>
        /// <returns></returns>
        ICollection<DTO> Query(Func<Entity, bool> predicate);

    }
}
