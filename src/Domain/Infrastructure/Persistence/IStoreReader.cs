#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Infrastructure.Persistence
{
    public interface IStoreReader
    {
        TEntity Read<TEntity>(string id);
        IEnumerable<TEntity> Read<TEntity>();
        IEnumerable<TEntity> Read<TEntity>(Func<TEntity, bool> predicate);
    }
}
