using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IGenericRepository<TKey, TEntity, TDto>
    {
        /// <summary>
        /// Lista todas as entidades do repositório.
        /// </summary>
        /// <returns>Lista de entidades convertida para o formato TDto</returns>
        ICollection<TDto> List();

        /// <summary>
        /// Busca uma entidade do repositório pela chave.
        /// </summary>
        /// <param name="chave">Chave da entidade</param>
        /// <returns>Entidade convertida para o formato TDto</returns>
        TDto Find(TKey chave);

        /// <summary>
        /// Adiciona uma entidade no repositório.
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <returns>Entidade salva convertida para o formato TDto</returns>
        TDto Save(TDto entidade);

        /// <summary>
        /// Atualiza um entidade já existente no repositório.
        /// </summary>
        /// <param name="entidade">Entidade a ser atualizada</param>
        /// <returns>Entidade atualizada convertida para o formato TDto</returns>
        TDto Update(TDto entidade);

        /// <summary>
        /// Exclui uma entidade do repositório pela chave.
        /// </summary>
        /// <param name="chave">Chave da entidade</param>
        /// <returns>Entidade excluída convertida para o formato TDto</returns>
        TDto Delete(TKey chave);

        /// <summary>
        /// Faz uma consulta com base no filtro enviado por parâmetro.
        /// </summary>
        /// <param name="predicate">Filtro (Predicate)</param>
        /// <returns>Lista de entidades convertida para TDto</returns>
        ICollection<TDto> Query(Func<TEntity, bool> predicate);

        /// <summary>
        /// Verifica a existência de uma entidade, a partir da chave.
        /// </summary>
        /// <param name="chave">Chave da entidade</param>
        /// <returns>true, se existe;false, se não</returns>
        bool Existe(TKey chave);
    }
}
