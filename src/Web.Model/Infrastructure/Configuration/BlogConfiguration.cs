#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    public class BlogConfiguration
    {
        public BlogConfiguration(string title, string heading, string twitter, string metadescription)
        {
            this.Title = title ?? String.Empty;
            this.Heading = heading ?? String.Empty;
            this.Twitter = twitter ?? String.Empty;
            this.MetaDescription = metadescription ?? String.Empty;
        }

        public string Title { get; private set; }
        public string Heading { get; private set; }
        public string Twitter { get; private set; }
        public string MetaDescription { get; private set; }
    }
}
