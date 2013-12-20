#region Libraries
using Blog.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
#endregion

namespace Blog.Service
{
    internal static class KnownTypes
    {
        public static Type Service { get { return typeof(IService); } }
    }
}