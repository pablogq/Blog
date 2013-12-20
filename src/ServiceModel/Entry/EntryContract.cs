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
    public class EntryContract
    {
        [DataMember]
        public string Slug { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
    }
}
