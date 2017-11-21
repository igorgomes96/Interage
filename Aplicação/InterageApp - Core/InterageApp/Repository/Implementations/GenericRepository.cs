using InterageApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Repository.Implementations
{
    public class GenericRepository<T, U> : IGenericRepository<T, U> where T: class
    {
        private readonly DbContext _db;

        public GenericRepository(DbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public T Create(T entidade)
        {
            return _db.Set<T>().Add(entidade).Entity;
        }

        public T Delete(U entidade)
        {
            throw new NotImplementedException();
        }

        public void Delete(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Filter(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Read(U chave)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
