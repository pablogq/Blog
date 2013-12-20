#region Libraries
using Blog.Domain.Model;
using Blog.Domain.Services;
using Blog.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace Blog.Service
{
    public class EntryService : IEntryService
    {
        private readonly IEntryDomainService domain;
        private readonly IMapper mapper;
        public EntryService(IEntryDomainService domain, IMapper mapper)
        {
            Guard.IsNotNull(domain, "domain");
            Guard.IsNotNull(mapper, "mapper");

            this.domain = domain;
            this.mapper = mapper;
        }

        public Response Save(EntryContract contract)
        {
            try
            {
                this.domain.Save(this.mapper.Map<Entry, EntryContract>(contract));
                return Response.Valid;
            }
            catch (Exception ex) 
            {
                return new Response(ex.Message);
            }
        }

        public EntryContract Get(string slug)
        {
            Entry entry = this.domain.GetBySlug(slug);
            return this.mapper.Map<EntryContract, Entry>(entry);
        }

        public IEnumerable<EntryContract> List()
        {
            return this.domain.Entries()
                              .Select(this.mapper.Map<EntryContract, Entry>)
                              .ToList();
        }

        public Response Delete(string slug)
        {
            try
            {
                this.domain.Delete(slug);
                return Response.Valid;
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }
    }
}