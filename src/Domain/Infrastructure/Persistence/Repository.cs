#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IStorage storage;
        private readonly IStoreReader reader;

        public Repository(IStorage storage, IStoreReader reader)
        {
            Guard.IsNotNull(storage, "storage");
            Guard.IsNotNull(reader, "reader");

            this.storage = storage;
            this.reader = reader;
        }

        public TEntity Find(string id)
        {
            Guard.IsNotNullOrEmpty(id, "id");

            return this.reader.Read<TEntity>(id);
        }

        public TEntity Single(Func<TEntity, bool> criteria)
        {
            Guard.IsNotNull(criteria, "criteria");

            return this.reader.Read(criteria)
                              .FirstOrDefault();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> filter)
        {
            Guard.IsNotNull(filter, "filter");

            return this.reader.Read(filter);
        }


        public void Save(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            this.storage.Store(entity);
        }

        public void Delete(TEntity entity)
        {
            Guard.IsNotNull(entity, "entity");

            this.storage.Remove(entity);
        }


        public IEnumerable<TEntity> All()
        {
            return this.reader.Read<TEntity>(entity => entity.IsNotNull());
        }
    }
}
