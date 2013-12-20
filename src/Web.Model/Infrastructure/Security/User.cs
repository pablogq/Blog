#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class User
    {
        public User(string friendlyName, bool isAuthenticated, bool isAdmin)
        {
            Guard.IsNotNullOrEmpty(friendlyName, "friendlyName");

            this.FriendlyName = friendlyName;
            this.IsAuthenticated = isAuthenticated;
            this.IsAdmin = isAdmin;
        }

        public string FriendlyName { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}
