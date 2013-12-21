#region Libraries
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Domain.Model
{
    public class Configuration
    {
        public static readonly Configuration Default = new Configuration { Title = "MyBlog", Heading = "MyBlog" };

        internal const string ID = "configuration";
        private ICollection<string> admins;
        private string title;
        private string twitter;
        private string heading;
        private string metadescription;

        public Configuration()
        {
            this.admins = new Collection<string>();
        }

        [Id]
        public string Id { get { return ID; } }

        public ICollection<string> Admins
        {
            get { return this.admins; }
            set
            {
                Guard.IsNotNull(value, "admins");

                this.admins = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value ?? String.Empty;
            }
        }

        public string Twitter
        {
            get { return this.twitter; }
            set
            {
                this.twitter = value ?? String.Empty;
            }
        }

        public string Heading
        {
            get { return this.heading; }
            set
            {
                this.heading = value ?? String.Empty;
            }
        }

        public string MetaDescription
        {
            get { return this.metadescription; }
            set
            {
                this.metadescription = value ?? String.Empty;
            }
        }

        public void Update(Configuration configuration)
        {
            Guard.IsNotNull(configuration, "configuration");

            this.Admins = configuration.Admins;
            this.Title = configuration.Title;
            this.Twitter = configuration.Twitter;
            this.Heading = configuration.Heading;
            this.MetaDescription = configuration.MetaDescription;
        }
    }
}
