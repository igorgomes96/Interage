using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IFeedbacksService
    {
        /// <summary>
        /// Lista todos os feedbacks de um Evento.
        /// </summary>
        /// <param name="codEvento">Código do Evento</param>
        /// <returns></returns>
        ICollection<FeedbackDto> List(int codEvento);

        /// <summary>
        /// Salva um feedback.
        /// </summary>
        /// <param name="feedback">Feedback do evento</param>
        /// <returns></returns>
        FeedbackDto SaveFeedback(FeedbackDto feedback);
    }
}
