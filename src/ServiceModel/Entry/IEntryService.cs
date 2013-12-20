#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text; 
#endregion

namespace Blog.ServiceModel
{
    [ServiceContract(Namespace = "http://www.blog-pablogq.com/entry")]
    public interface IEntryService : IService
    {
        [OperationContract]
        Response Save(EntryContract contract);
        [OperationContract]
        EntryContract Get(string slug);
        [OperationContract]
        IEnumerable<EntryContract> List();
        [OperationContract]
        Response Delete(string slug);
    }
}
