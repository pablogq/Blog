#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class FixedTokenAuthenticator : IAuthenticator
    {
        private const string TOKEN = "my-secret-token";

        public bool Authenticate(string token)
        {
            return String.Equals(TOKEN, token);
        }
    }
}
