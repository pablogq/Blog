using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Infrastructure.Persistence
{
    public interface IStorage
    {
        void Store<TEntity>(TEntity entity);
        void Remove<TEntity>(TEntity entity);
    }
}
