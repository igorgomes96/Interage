using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Envia um email.
        /// </summary>
        /// <param name="email">Objeto EmailDto. (O tipo do parâmetro é object para poder ser enviado por thread)</param>
        void Send(object email);
    }
}
