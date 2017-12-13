using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IInscricoesEventosRepository
    {
        /// <summary>
        /// Inscreve um usuário em um evento.
        /// </summary>
        /// <param name="idEvento">Código do evento no qual o usuário deseja se inscrever</param>
        /// <param name="emailUsuario">Email do usuário que deseja se inscrever</param>
        void InscreverParticipante(int idEvento, string emailUsuario);

        /// <summary>
        /// Cancela a inscrição de um usuário.
        /// </summary>
        /// <param name="idEvento">Código do evento no qual o usuário deseja cancelar sua inscrição</param>
        /// <param name="emailUsuario">Email do usuário que deseja cancelar sua inscrição</param>
        void CancelarInscricao(int idEvento, string emailUsuario);

        /// <summary>
        /// Verifica se um usuário está inscrito em um evento.
        /// </summary>
        /// <param name="idEvento">Código do evento a ser verificado</param>
        /// <param name="emailUsuario">Email do usuário a ser verificado</param>
        /// <returns></returns>
        bool VerificaInscricao(int idEvento, string emailUsuario);
    }
}
