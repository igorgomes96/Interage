using InterageApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using System.Data.Entity;
using InterageApp.Models;

namespace InterageApp.Repository.Implementations
{
    public class AuthValidateRepository : IAuthValidateRepository
    {
        private readonly DbContext _db;

        public AuthValidateRepository(DbContext db)
        {
            _db = db;
        }

        public Usuario GetCredenciais(string email)
        {
            Usuario user = _db.Set<Usuario>().Find(email);

            return user;
        }
    }
}