#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
#endregion

namespace Blog.ServiceModel.Soap
{
    public abstract class SoapClientBase<TClient> : ClientBase<TClient>, IClient
        where TClient : class, IClient
    {
        protected SoapClientBase(Binding binding, EndpointAddress endpointAddress)
            : base(binding, endpointAddress)
        { }

        public static TClient Create(string endpointAddress)
        {
            Guard.IsNotNullOrEmpty(endpointAddress, "endpointAddress");

            BasicHttpBinding httpBinding = new BasicHttpBinding() { MaxBufferPoolSize = 2147483647, MaxReceivedMessageSize = 2147483647 };
            EndpointAddress endpoint = new EndpointAddress(endpointAddress);

            return Create(httpBinding, endpoint);
        }

        public static TClient Create(Binding binding, EndpointAddress endpointAddress)
        {
            Guard.IsNotNull(binding, "binding");
            Guard.IsNotNull(endpointAddress, "endpointAddress");

            ChannelFactory<TClient> factory = new ChannelFactory<TClient>(binding, endpointAddress);
            factory.Endpoint
                   .Contract
                   .Operations
                   .ForEach(operation =>
                   {
                       DataContractSerializerOperationBehavior dataContract = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                       if (dataContract != null)
                       {
                           dataContract.MaxItemsInObjectGraph = 2147483647;
                       }
                   });

            return factory.CreateChannel();
        }
    }
}
