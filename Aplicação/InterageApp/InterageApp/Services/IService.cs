using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services
{
    public interface IService<Entity, DTO, Chave> where Entity : class where DTO : class
    {
        /// <summary>
        /// Retorna uma lista com todas as entidades.
        /// </summary>
        /// <returns>Uma lista com todas as entidades</returns>
        ICollection<DTO> Read();

        /// <summary>
        /// Procura uma entidade pela chave.
        /// </summary>
        /// <param name="chave">Chave da entidade procurado</param>
        /// <returns>Entidade encontrado</returns>
        /// <exception cref="NotFoundException">Não foi encontrada nenhuma entidade com a chave informada.</exception>
        DTO Read(Chave chave);

        /// <summary>
        /// Insere ou atualiza uma entidade no banco de dados.
        /// </summary>
        /// <param name="resource">Entitdade</param>
        /// <returns>Entidade salvo</returns>
        DTO Save(DTO resource);

        /// <summary>
        /// Procura uma entidade pela chave, e exclui.
        /// </summary>
        /// <param name="chave">Chave da entidade procurado</param>
        /// <returns>Entidade excluída</returns>
        /// <exception cref="NotFoundException">Não foi encontrada nenhuma entidade com a chave informada.</exception>
        DTO Delete(Chave chave);
    }
}
