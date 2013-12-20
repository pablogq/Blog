#region Libraries
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

        public User User 
        { 
            get { return this.user; }
            set
            {
                Guard.IsNotNull(value, "user");

                this.user = value;
            }
        }
    }
}
