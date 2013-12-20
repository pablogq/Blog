#region Libraries
using Blog.Domain.Model;
using Blog.Infrastructure.Persistence;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            this.session.Store(entity, this.GetId(entity));
        }

        public void Remove<TEntity>(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            this.session.Delete(entity);
        }

        protected virtual string GetId<TEntity>(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            PropertyInfo propertyMarkedAsId = entity.GetType()
                                                    .GetProperties()
                                                    .FirstOrDefault(property => property.GetCustomAttributes<IdAttribute>().Any());
            if (propertyMarkedAsId.IsNull()) 
            {
                throw new ArgumentException("The entity {0} doesn't contain any field marked with the Id attribute.".FormatWith(entity.GetType().FullName));
            }
            object idValue = propertyMarkedAsId.GetValue(entity, null);
            Guard.IsNotNull(idValue, "id");

            return idValue.ToString();
        }
    }
}
