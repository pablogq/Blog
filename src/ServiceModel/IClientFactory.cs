#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.ServiceModel
{
    public interface IClientFactory<TClient>
        where TClient : IClient
    {
        TClient Create();
        void Release(TClient client);
    }
}
