#region Libraries
using Blog.Domain.Model;
using Blog.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Domain.Services
{
    public class EntryDomainService : IEntryDomainService
    {
        private readonly IRepository<Entry> repository;

        public EntryDomainService(IRepository<Entry> repository)
        {
            Guard.IsNotNull(repository, "repository");

            this.repository = repository;
        }

        public void Save(Entry entry)
        {
            Guard.IsNotNull(entry, "entry");

            Entry toSave = this.repository.FindOrDefault(entry.Slug)
                                          .Do(e => e.Update(entry))
                                          .DefaultIfEmpty(entry)
                                          .Single();

            this.repository.Save(toSave);
        }

        public Entry GetBySlug(string slug)
        {
            return this.repository.Find(slug);
        }

        public IEnumerable<Entry> Entries()
        {
            return this.repository.All();
        }

        public void Delete(string slug)
        {
            Guard.IsNotNullOrEmpty(slug, "slug");
            
            Entry entry = this.GetBySlug(slug);
            if (entry.IsNull()) 
            {
                throw new InvalidOperationException("La publicacion que esta intentando eliminar no existe.");
            }
            this.repository.Delete(entry);
        }
    }
}
