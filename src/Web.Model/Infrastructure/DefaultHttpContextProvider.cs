#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web; 
#endregion

namespace Blog.Web.Model.Infrastructure
{
    public class DefaultHttpContextProvider : IHttpContextProvider
    {
        public HttpContextBase Current { get { return new HttpContextWrapper(HttpContext.Current); } }
    }
}
