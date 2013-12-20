#region Libraries
using Blog.Infrastructure.Persistence;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Infrastructure.Raven.Persistence
{
    public class RavenDbStorage : IStorage, IStoreReader
    {
        private readonly IDocumentSession session;
        public RavenDbStorage(IDocumentSession session)
        {
            Guard.IsNotNull(session, "session");

            this.session = session;
        }

        public TEntity Read<TEntity>(string id)
        {
            Guard.IsNotNullOrEmpty(id, "id");

            return this.session.Load<TEntity>(id);
        }

        public IEnumerable<TEntity> Read<TEntity>()
        {
            return this.session.Query<TEntity>();
        }

        public IEnumerable<TEntity> Read<TEntity>(Func<TEntity, bool> predicate)
        {
            return this.session.Query<TEntity>()
                               .Where(predicate);
        }

        public void Store<TEntity>(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            this.session.Store(entity);
        }

        public void Remove<TEntity>(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            this.session.Delete(entity);
        }
    }
}
