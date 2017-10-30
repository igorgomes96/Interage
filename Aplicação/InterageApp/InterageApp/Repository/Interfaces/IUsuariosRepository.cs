using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IUsuariosRepository : IGenericRepository<UsuarioDTO, string>
    {
        UsuarioDTO Create(UsuarioCredenciaisDTO entidade);
    }
}
