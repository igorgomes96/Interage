using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Mapping.Interfaces
{
    public interface IGenericMappingService<TSource, TDestination>
    {
        TSource Map(TDestination entity);
        TDestination Map(TSource entity);
        IEnumerable<TSource> Map(IEnumerable<TDestination> entities);
        IEnumerable<TDestination> Map(IEnumerable<TSource> entities);
    }
}
