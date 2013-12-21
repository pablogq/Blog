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
    public class ConfigurationDomainService : IConfigurationDomainService
    {
        private readonly IRepository<Configuration> repository;

        public ConfigurationDomainService(IRepository<Configuration> repository)
        {
            Guard.IsNotNull(repository, "repository");

            this.repository = repository;
        }

        public void Save(Configuration configuration)
        {
            Guard.IsNotNull(configuration, "configuration");

            Configuration toSave = this.repository.FindOrDefault(configuration.Id)
                                                  .Do(c => c.Update(configuration))
                                                  .DefaultIfEmpty(configuration)
                                                  .Single();

            this.repository.Save(toSave);
        }

        public Configuration Get()
        {
            return this.repository.Find(Configuration.ID)
                                  .ToMaybe<Configuration>()
                                  .DefaultIfEmpty(Configuration.Default)
                                  .Single();
        }
    }
}
