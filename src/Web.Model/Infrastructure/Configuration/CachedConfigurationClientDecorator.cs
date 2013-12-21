#region Libraries
using Blog.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching; 
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    public class CachedConfigurationClientDecorator : IConfigurationClient
    {
        private const string KEY = "$configuration$";
        private readonly IConfigurationClient client;
        private readonly IHttpContextProvider httpContext;


        public CachedConfigurationClientDecorator(IConfigurationClient client, IHttpContextProvider httpContext)
        {
            Guard.IsNotNull(client, "client");
            Guard.IsNotNull(httpContext, "httpContext");

            this.client = client;
            this.httpContext = httpContext;
        }

        protected Cache Cache { get { return this.httpContext.Current.Cache; } }

        public Response Save(ConfigurationContract contract)
        {
            Response response = this.client.Save(contract);
            if (response.Success) 
            {
                this.InsertIntoCache(contract);
            }

            return response;
        }

        public ConfigurationContract Get()
        {
            ConfigurationContract contract = this.Cache.GetAs<ConfigurationContract>(KEY);
            if (contract.IsNotNull()) 
            {
                return contract;
            }

            contract = this.client.Get();
            this.InsertIntoCache(contract);

            return contract;
        }

        public void Dispose()
        {
            this.client.Dispose();
        }

        private void InsertIntoCache(ConfigurationContract contract) 
        {
            this.Cache.Insert(KEY, contract, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
        }
    }
}
