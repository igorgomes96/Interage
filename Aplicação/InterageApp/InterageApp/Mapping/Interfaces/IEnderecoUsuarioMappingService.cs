using InterageApp.DTO;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Interfaces
{
    public interface IEnderecoUsuarioMappingService
    {
        EnderecoUsuario Map(UsuarioDTO usuario);
    }
}
