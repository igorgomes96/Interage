using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IGenericService<T, U>
    {
        T Create(T entidade);
        T Read(U chave);
        ICollection<T> ReadAll();
        T Update(T entidade);
        T Delete(U chave);
        void Delete(Func<T, bool> predicate);
        ICollection<T> Filter(Func<T, bool> predicate);
    }
}
