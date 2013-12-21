#region Libraries
using Blog.Web.Model.Infrastructure.Configuration;
using Blog.Web.Model.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class LayoutViewModel
    {
        private User user;
        private BlogConfiguration configuration;

        public User User 
        { 
            get { return this.user; }
            set
            {
                Guard.IsNotNull(value, "user");

                this.user = value;
            }
        }

        public BlogConfiguration Configuration
        {
            get { return this.configuration; }
            set
            {
                Guard.IsNotNull(value, "configuration");

                this.configuration = value;
            }
        }
    }
}
