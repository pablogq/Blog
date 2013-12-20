#region Libraries
using Blog.ServiceModel;
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
        public static Type ClientFactory { get { return typeof(IClientFactory<>); } }
        public static Type ContentTransformator { get { return typeof(IContentTransformator); } }
    }
}