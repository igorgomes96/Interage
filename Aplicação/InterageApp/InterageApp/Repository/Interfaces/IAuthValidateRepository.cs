using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IAuthValidateRepository
    {
        /// <summary>
        /// Busca as credenciais do usuário no banco.
        /// </summary>
        /// <param name="email">Email do Usuário</param>
        /// <returns>Credenciais do usuário</returns>
        Usuario GetCredenciais(string email);
    }
}
