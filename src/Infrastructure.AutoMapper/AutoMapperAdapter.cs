#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mapper = AutoMapper.Mapper;
#endregion

namespace Blog.Infrastructure.AutoMapper
{
    public class AutoMapperAdapter : IMapper
    {
        public TDestination Map<TDestination, TSource>(TSource source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
