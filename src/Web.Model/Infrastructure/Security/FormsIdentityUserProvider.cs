#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Security;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class FormsIdentityUserProvider : IUserProvider
    {
        private readonly IHttpContextProvider httpContext;
        private readonly IAuthorizer authorizer;

        private User user;
        
        public FormsIdentityUserProvider(IHttpContextProvider httpContext, IAuthorizer authorizer)
        {
            Guard.IsNotNull(httpContext, "httpContext");
            Guard.IsNotNull(authorizer, "authorizer");

            this.httpContext = httpContext;
            this.authorizer = authorizer;
        }

        public User Current { get { return this.user ?? (this.user = this.GetUserFromHttpContext()); } }

        private User GetUserFromHttpContext() 
        {
            IIdentity identity = this.httpContext.Current.User.Identity;
            FormsIdentity formsIdentity = identity as FormsIdentity;

            string friendlyName = formsIdentity.IsNotNull() ? formsIdentity.Ticket.UserData : identity.Name;
            bool isAdmin = identity.IsAuthenticated;

            return new User(friendlyName, identity.IsAuthenticated, isAdmin);
        }
    }
}
