#region Libraries
using Blog.Web.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Controllers
{
    public class EntryController : LayoutController
    {
        public EntryController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }
    }
}
