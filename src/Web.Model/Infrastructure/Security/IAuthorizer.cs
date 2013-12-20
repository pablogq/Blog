#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web; 
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public interface IAuthorizer
    {
        bool Authorize(IIdentity identity);
    }
}
