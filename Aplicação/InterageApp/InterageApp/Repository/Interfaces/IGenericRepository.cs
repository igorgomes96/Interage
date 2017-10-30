using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Repository.Interfaces
{
    public interface IGenericRepository<T, U>
    {
        
        IQueryable<T> ReadAll();
        T Read(U chave);
        T Create(T entidade);
        T Update(T entidade);
        T Delete(U chave);
        void Delete(Func<T, bool> predicate);
        IQueryable<T> Filter(Func<T, bool> predicate);
    }
}
