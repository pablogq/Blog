#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Blog.Web.UI
{
    internal static class KnownTypes
    {
        public static Type Controller { get { return typeof(IController); } }
    }
}