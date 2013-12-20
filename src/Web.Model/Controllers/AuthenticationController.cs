#region Libraries
using Blog.Web.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Controllers
{
    public class AuthenticationController : LayoutController
    {
        public AuthenticationController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }
    }
}
