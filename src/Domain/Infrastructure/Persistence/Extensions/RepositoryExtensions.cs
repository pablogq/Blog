#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Infrastructure.Persistence
{
    public static class RepositoryExtensions
    {
        public static Maybe<TEntity> FindOrDefault<TEntity>(this IRepository<TEntity> repository, string id)
            where TEntity : class
        {
            Guard.IsNotNull(repository, "repository");

            return repository.Find(id).ToMaybe();
        }

        public static Maybe<TEntity> SingleOrDefault<TEntity>(this IRepository<TEntity> repository, Func<TEntity, bool> criteria)
            where TEntity : class
        {
            Guard.IsNotNull(repository, "repository");

            return repository.Single(criteria).ToMaybe();
        }
    }
}
