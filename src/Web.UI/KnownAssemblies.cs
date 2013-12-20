#region Libraries
using Blog.ServiceModel;
using Blog.Web.Model.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web; 
#endregion

namespace Blog.Web.UI
{
    internal static class KnownAssemblies
    {
        public static Assembly WebModel { get { return typeof(LayoutController).Assembly; } }
        public static Assembly ServiceModel { get { return typeof(IService).Assembly; } }
    }
}