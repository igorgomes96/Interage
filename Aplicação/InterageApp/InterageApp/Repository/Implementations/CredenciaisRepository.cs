using InterageApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterageApp.DTO;
using Microsoft.EntityFrameworkCore;
using InterageApp.Models;
using InterageApp.Mapping.Interfaces;
using System.Text;

namespace InterageApp.Repository.Implementations
{
    public class CredenciaisRepository : ICredenciaisRepository
    {
        private readonly DbContext _db;
        private readonly IGenericMappingService<CredenciaisDTO, Credenciais> _credenciaisMap;

        public CredenciaisRepository(DbContext db, IGenericMappingService<CredenciaisDTO, Credenciais> credenciaisMap)
        {
            _db = db ?? throw new ArgumentNullException();
            _credenciaisMap = credenciaisMap ?? throw new ArgumentNullException();
        }
        public CredenciaisDTO Create(CredenciaisDTO credenciais)
        {
            Credenciais c = _credenciaisMap.Map(credenciais);
            _db.Set<Credenciais>().Add(c);
            _db.SaveChanges();
            return _credenciaisMap.Map(c);
        }

        public void Delete(string email)
        {
            Credenciais c = _db.Set<Credenciais>().Find(email);
            if (c != null)
            {
                _db.Remove(c);
                _db.SaveChanges();
            }
        }

        public string GenerateRecuperationCode(string email)
        {
            Credenciais c = _db.Set<Credenciais>().Find(email);
            var plainText = c.Email + ":" + c.Senha;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        public CredenciaisDTO Recuperate(string codeRecuperation, string novaSenha)
        {
            var text = Encoding.UTF8.GetString(Convert.FromBase64String(codeRecuperation));
            Credenciais c = _db.Set<Credenciais>().Find(text.Split(":")[0]);
            c.Senha = novaSenha;
            _db.SaveChanges();
            return _credenciaisMap.Map(c);

        }
    }
}
