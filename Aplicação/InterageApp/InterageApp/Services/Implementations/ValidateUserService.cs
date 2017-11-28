using InterageApp.DTO;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using InterageApp.Services.Interfaces;

namespace InterageApp.Services.Implementations
{
    public class ValidateUserService : IValidateUserService
    {
        private readonly IAuthValidateRepository _rep;

        public ValidateUserService(IAuthValidateRepository rep)
        {
            _rep = rep;
        }

        public bool CheckUser(CredenciaisDto credenciais)
        {
            Usuario user = _rep.GetCredenciais(credenciais.Email);
            if (user != null && user.Senha == credenciais.Senha) return true;
            return false;
        }
    }
}