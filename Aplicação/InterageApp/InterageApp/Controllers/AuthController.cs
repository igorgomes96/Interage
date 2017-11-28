using InterageApp.Auth;
using InterageApp.DTO;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InterageApp.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IValidateUserService _validateUser;

        public AuthController(IValidateUserService validateUser)
        {
            _validateUser = validateUser;
        }

        [HttpPost]
        public IHttpActionResult Authenticate(CredenciaisDto credenciais)
        {
            if (_validateUser.CheckUser(credenciais))
            {
                return Ok(JwtManager.GenerateToken(credenciais.Email, 120));
            }
            return Content(HttpStatusCode.BadRequest, "Credenciais inválidas");
        }
    }
}
