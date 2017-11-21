using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Mapping
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TSource Map(TDestination destination);
        ICollection<TDestination> Map(ICollection<TSource> source);
        ICollection<TSource> Map(ICollection<TDestination> destination);
    }
}
