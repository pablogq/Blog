#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
#endregion

namespace Blog.ServiceModel
{
    [DataContract]
    public class Response
    {
        public readonly static Response Valid = new Response();

        public Response()
        {
            this.Messages = new List<string>();
        }

        public Response(params string[] messages)
        {
            Guard.IsNotNull(messages, "messages");

            this.Messages = messages;
        }

        public bool Success { get { return this.Messages.IsNullOrEmpty(); } }
        [DataMember]
        public IEnumerable<string> Messages { get; set; }
    }
}
