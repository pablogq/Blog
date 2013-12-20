#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class DeleteViewModel : LayoutViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
