#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching; 
#endregion

namespace Blog.Web.Model
{
    public static class CacheExtensions
    {
        public static TValue Get<TValue>(this Cache cache, string key) 
        {
            Guard.IsNotNull(cache, "cache");

            return (TValue)cache.Get(key);
        }

        public static TValue GetAs<TValue>(this Cache cache, string key)
            where TValue : class
        {
            Guard.IsNotNull(cache, "cache");

            return cache.Get(key) as TValue;
        }
    }
}
