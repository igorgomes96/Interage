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
        Usuario GetCredenciais(string email);
    }
}
