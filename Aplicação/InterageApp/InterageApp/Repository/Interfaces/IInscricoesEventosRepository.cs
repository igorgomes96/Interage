using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IInscricoesEventosRepository
    {
        void InscreverParticipante(int idEvento, string emailUsuario);
        void CancelarInscricao(int idEvento, string emailUsuario);
        bool VerificaInscricao(int idEvento, string emailUsuario);
    }
}
