#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
#endregion

namespace Blog.Web.Model.Infrastructure
{
    public interface IHttpContextProvider
    {
        HttpContextBase Current { get; }
    }
}
