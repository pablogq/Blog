#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
#endregion

namespace Blog.ServiceModel
{
    [ServiceContract(Namespace = "http://www.blog-pgq.com/configuration")]
    public interface IConfigurationService : IService
    {
        [OperationContract]
        Response Save(ConfigurationContract contract);
        [OperationContract]
        ConfigurationContract Get();
    }
}
