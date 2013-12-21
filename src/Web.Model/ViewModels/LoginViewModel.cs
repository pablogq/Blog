#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class LoginViewModel : LayoutViewModel
    {
        public string Token { get; set; }
        public string ReturnUrl { get; set; }
        public string Message { get; set; }
    }
}
