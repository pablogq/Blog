#region Libraries
using Blog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Domain.Services
{
    public interface IEntryDomainService
    {
        void Save(Entry entry);
        Entry GetBySlug(string slug);
        IEnumerable<Entry> Entries();
        void Delete(string slug);
    }
}
