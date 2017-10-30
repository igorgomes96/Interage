using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface ICredenciaisRepository
    {
        CredenciaisDTO Create(CredenciaisDTO credenciais);
        void Delete(string email);
        string GenerateRecuperationCode(string email);
        CredenciaisDTO Recuperate(string codeRecuperation, string novaSenha);
    }
}
