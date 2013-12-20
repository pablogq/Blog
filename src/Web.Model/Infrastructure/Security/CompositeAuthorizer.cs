#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class CompositeAuthorizer : IAuthorizer
    {
        private readonly IEnumerable<IAuthorizer> authorizers;

        public CompositeAuthorizer(IEnumerable<IAuthorizer> authorizers)
        {
            Guard.IsNotNull(authorizers, "authorizers");

            this.authorizers = authorizers;
        }

        public bool Authorize(IIdentity identity)
        {
            Guard.IsNotNull(identity, "identity");

            return this.authorizers.Any(authorizer => authorizer.Authorize(identity));
        }
    }
}
