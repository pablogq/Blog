#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.ServiceModel
{
    public static class ClientFactoryExtensions
    {
        public static void Do<TClient>(this IClientFactory<TClient> factory, Action<TClient> action)
            where TClient : IClient
        {
            Guard.IsNotNull(factory, "factory");
            Guard.IsNotNull(action, "action");

            using (TClient client = factory.Create())
            {
                action(client);
                factory.Release(client);
            }
        }

        public static TValue Get<TClient, TValue>(this IClientFactory<TClient> factory, Func<TClient, TValue> function)
            where TClient : IClient
        {
            Guard.IsNotNull(factory, "factory");
            Guard.IsNotNull(function, "function");

            TValue value = default(TValue);
            using (TClient client = factory.Create())
            {
                value = function(client);
                factory.Release(client);
            }
            return value;
        }
    }
}
