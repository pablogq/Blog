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
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationDomainService domain;
        private readonly IMapper mapper;

        public ConfigurationService(IConfigurationDomainService domain, IMapper mapper)
        {
            Guard.IsNotNull(domain, "domain");
            Guard.IsNotNull(mapper, "mapper");

            this.domain = domain;
            this.mapper = mapper;
        }
        
        public Response Save(ConfigurationContract contract)
        {
            try
            {
                this.domain.Save(this.mapper.Map<Configuration, ConfigurationContract>(contract));
                return Response.Valid;
            }
            catch (Exception ex)
            {
                return new Response(ex.Message);
            }
        }

        public ConfigurationContract Get()
        {
            return this.mapper.Map<ConfigurationContract, Configuration>(this.domain.Get());
        }
    }
}