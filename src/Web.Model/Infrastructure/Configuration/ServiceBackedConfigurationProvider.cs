#region Libraries
using Blog.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    public class ServiceBackedConfigurationProvider : IConfigurationProvider
    {
        private readonly IClientFactory<IConfigurationClient> configurationService;
        private readonly IMapper mapper;

        public ServiceBackedConfigurationProvider(IClientFactory<IConfigurationClient> configurationService, IMapper mapper)
        {
            Guard.IsNotNull(configurationService, "configurationService");
            Guard.IsNotNull(mapper, "mapper");

            this.configurationService = configurationService;
            this.mapper = mapper;
        }

        public BlogConfiguration Current { get { return this.configurationService.Get(client => this.mapper.Map<BlogConfiguration, ConfigurationContract>(client.Get())); } }
    }
}
