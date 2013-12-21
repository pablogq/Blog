#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class EntrySummaryViewModel : LayoutViewModel
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string PrettyDate { get; set; }
        public string TruncatedContent { get; set; }
        public bool IsPublished { get; set; }
    }
}
