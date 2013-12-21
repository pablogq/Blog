#region Libraries
using Blog.Web.Model.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class ConfigFileAuthorizer : IAuthorizer
    {
        private readonly IConfigurationManager configurationManager;
        public ConfigFileAuthorizer(IConfigurationManager configurationManager)
        {
            Guard.IsNotNull(configurationManager, "configurationManager");

            this.configurationManager = configurationManager;
        }

        public bool Authorize(IIdentity identity)
        {
            string admin = this.configurationManager.AppSettings["admin"];
            if (admin.IsNullOrEmpty()) 
            {
                return false;
            }
            return admin.Split(',').Any(a => String.Equals(identity.Name, a, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
