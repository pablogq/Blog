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
    public class ConfigurationContract 
    {
        public ConfigurationContract()
        {
            this.Admins = new List<string>();
        }

        [DataMember]
        public List<string> Admins { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Heading { get; set; }
        [DataMember]
        public string Twitter { get; set; }
        [DataMember]
        public string MetaDescription { get; set; }
    }
}
