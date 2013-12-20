#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source);
    }
}
