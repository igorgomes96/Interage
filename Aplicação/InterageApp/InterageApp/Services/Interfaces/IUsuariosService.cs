using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IUsuariosService : IGenericService<UsuarioDTO, string>
    {
        UsuarioDTO Create(UsuarioCredenciaisDTO user);
        ClaimsIdentity GetClaimsIdentity(UsuarioDTO user);
    }
}
