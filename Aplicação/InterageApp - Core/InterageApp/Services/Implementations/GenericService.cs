using InterageApp.Repository.Interfaces;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Services.Implementations
{
    public class GenericService<T, U> : IGenericService<T, U> where T : class
    {

        private readonly IGenericRepository<T, U> _repository;

        public T Create(T entidade)
        {
            return _repository.Create(entidade);
        }

        public T Delete(U chave)
        {
            return _repository.Delete(chave);
        }

        public void Delete(Func<T, bool> predicate)
        {
            
        }

        public ICollection<T> Filter(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T Read(U chave)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
