using InterageApp.Exceptions;
using InterageApp.Models;
using InterageApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace InterageApp.Filters
{
    public class AuthenticationFilter : Attribute, IAuthenticationFilter
    {

        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            IAuthService _authService = new AuthService(new CryptoService());

            // 1. Look for credentials in the request.
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            // 2. If there are no credentials, do nothing.
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Requisição sem credenciais!", request);
                return;
            }

            // 3. If there are credentials but the filter does not recognize the authentication scheme, do nothing.
            if (authorization.Scheme != "Basic")
            {
                context.ErrorResult = new AuthenticationFailureResult("Tipo de autenticação não reconhecida!", request);
                return;
            }

            // 4. If there are credentials that the filter understands, try to validate them.
            // 5. If the credentials are bad, set the error result.
            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Credenciais não encontradas", request);
                return;
            }

            string Token = authorization.Parameter;

            IPrincipal principal = await _authService.Authenticate(Token);
            if (principal == null)
                context.ErrorResult = new AuthenticationFailureResult("Usuário não autenticado ou sessão expirada!", request);

            // 6. If the credentials are valid, set principal.
            else
            {
                context.Principal = principal;
                Thread.CurrentPrincipal = principal;
            }

            return;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}