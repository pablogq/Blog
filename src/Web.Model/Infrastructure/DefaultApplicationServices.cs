#region Libraries
using Blog.ServiceModel;
using Blog.Web.Model.Infrastructure.Configuration;
using Blog.Web.Model.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.Infrastructure
{
    public class DefaultApplicationServices : IApplicationServices
    {
        private readonly IUserProvider userProvider;
        private readonly IHttpContextProvider httpContextProvider;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IClientFactory<IEntryClient> entryService;
        private readonly IMapper mapper;

        public DefaultApplicationServices(IUserProvider userProvider, 
                                          IHttpContextProvider httpContextProvider,
                                          IConfigurationProvider configurationProvider,
                                          IClientFactory<IEntryClient> entryService,
                                          IMapper mapper)
        {
            Guard.IsNotNull(userProvider, "userProvider");
            Guard.IsNotNull(httpContextProvider, "httpContextProvider");
            Guard.IsNotNull(configurationProvider, "configurationProvider");
            Guard.IsNotNull(entryService, "entryService");
            Guard.IsNotNull(mapper, "mapper");

            this.userProvider = userProvider;
            this.httpContextProvider = httpContextProvider;
            this.configurationProvider = configurationProvider;
            this.entryService = entryService;
            this.mapper = mapper;
        }

        public IUserProvider User { get { return this.userProvider; } }
        public IHttpContextProvider HttpContext { get { return this.httpContextProvider; } }
        public IClientFactory<IEntryClient> EntryService { get { return this.entryService; } }
        public IConfigurationProvider Configuration { get { return this.configurationProvider; } }
        public IMapper Mapper { get { return this.mapper; } }
    }
}
