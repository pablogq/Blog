#region Libraries
using Blog.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
#endregion

namespace Blog.Service
{
    internal static class KnownAssemblies
    {
        public static Assembly Service { get { return typeof(EntryService).Assembly; } }
        public static Assembly ServiceModel { get { return typeof(IService).Assembly; } }
    }
}