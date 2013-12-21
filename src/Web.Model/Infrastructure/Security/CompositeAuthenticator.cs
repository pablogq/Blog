#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class CompositeAuthenticator : IAuthenticator
    {
        private readonly IEnumerable<IAuthenticator> authenticators;

        public CompositeAuthenticator(IEnumerable<IAuthenticator> authorizers)
        {
            Guard.IsNotNull(authorizers, "authorizers");

            this.authenticators = authorizers;
        }

        public bool Authenticate(string token)
        {
 	        Guard.IsNotNullOrEmpty(token, "token");

            return this.authenticators.Any(authorizer => authorizer.Authenticate(token));
        }
    }
}
