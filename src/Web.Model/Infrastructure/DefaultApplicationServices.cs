#region Libraries
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

        public DefaultApplicationServices(IUserProvider userProvider, IHttpContextProvider httpContextProvider)
        {
            Guard.IsNotNull(userProvider, "userProvider");
            Guard.IsNotNull(httpContextProvider, "httpContextProvider");

            this.userProvider = userProvider;
            this.httpContextProvider = httpContextProvider;
        }

        public IUserProvider User { get { return this.userProvider; } }
        public IHttpContextProvider HttpContext { get { return this.httpContextProvider; } }
    }
}
