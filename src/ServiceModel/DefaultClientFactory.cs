#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.ServiceModel
{
    public class DefaultClientFactory<TClient> : IClientFactory<TClient>
        where TClient : IClient
    {
        private Func<TClient> factory;

        public virtual TClient Create()
        {
            this.EnsureFactoryMethod();

            return this.factory();
        }

        public virtual void Release(TClient client)
        {
            client.Dispose();
        }

        public virtual void SetFactoryMethod(Func<TClient> factoryMethod)
        {
            Guard.IsNotNull(factoryMethod, "factoryMethod");

            this.factory = factoryMethod;
        }

        private void EnsureFactoryMethod()
        {
            if (this.factory.IsNull())
            {
                throw new NullReferenceException("The factory method of hasn't been set. You must initialize it using the SetFactoryMethod method of the class.");
            }
        }
    }
}
