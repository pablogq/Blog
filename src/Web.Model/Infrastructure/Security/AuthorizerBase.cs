#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public abstract class AuthorizerBase : IAuthorizer
    {
        public bool Authorize(IIdentity identity)
        {
            Guard.IsNotNull(identity, "identity");

            return identity.IsAuthenticated && this.AuthorizeCore(identity);
        }

        protected abstract bool AuthorizeCore(IIdentity identity);
    }
}
