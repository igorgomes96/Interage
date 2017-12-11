using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IInteracaoService
    {
        /// <summary>
        /// Retorna as interações da sala de discussao de uma atividade
        /// </summary>
        /// <param name="idAtividade"></param>
        /// <returns></returns>
        ICollection<InteracaoDto> List(int idAtividade);


        /// <summary>
        /// Envia uma mensagem para sala de discussão
        /// </summary>
        /// <param name="interacao"></param>
        /// <returns></returns>
        InteracaoDto EnviarMensagem(InteracaoDto codAtividade);

    }
}
