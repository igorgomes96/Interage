using InterageApp.Mapping.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Interfaces
{
    public interface IMapper<TSource, TDestination> : ISingleMapper<TSource, TDestination>, ICollectionMapper<TSource, TDestination>
    {

    }
}
