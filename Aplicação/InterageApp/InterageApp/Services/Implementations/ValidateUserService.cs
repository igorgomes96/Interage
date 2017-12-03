using InterageApp.DTO;
using InterageApp.Exceptions;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using InterageApp.Services.Interfaces;
using System.Threading;

namespace InterageApp.Services.Implementations
{
    public class ValidateUserService : IValidateUserService
    {
        private readonly IAuthValidateRepository _rep;
        private readonly IEmailService _emailService;

        public ValidateUserService(IAuthValidateRepository rep, IEmailService emailService)
        {
            _rep = rep;
            _emailService = emailService;
        }

        public bool CheckUser(CredenciaisDto credenciais)
        {
            Usuario user = _rep.GetCredenciais(credenciais.Email);
            if (user != null && user.Senha == credenciais.Senha) return true;
            return false;
        }

        public void RecuperarSenha(string emailUsuario)
        {
            Usuario user = _rep.GetCredenciais(emailUsuario);
            if (user == null) throw new NaoEncontradoException<Usuario>("O e-mail informado não está cadastrado na nossa base de dados!");

            EmailDto email = new EmailDto();
            email.To.Add(emailUsuario);
            email.Subject = "Recuperação de Senha - Interage App";
            email.Message = string.Format("<strong>Interage App - Recuperação de Senha</strong><br>Segue a senha cadastrada em nossa base de dados: {0}<br><br><p style='color: #777'>Equipe Interage</p>", user.Senha);
            Thread th = new Thread(_emailService.Send);
            th.Start(email);
        }
    }
}