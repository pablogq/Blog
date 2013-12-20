#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Infrastructure.Persistence
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Single(Func<TEntity, bool> criteria);
        TEntity Find(string id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> filter);
        IEnumerable<TEntity> All();
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}
