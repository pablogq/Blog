#region Libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class EditorViewModel : LayoutViewModel
    {
        public string Slug { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter the title of this post.")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please enter some content.")]
        public string Content { get; set; }

        [DisplayName("Published")]
        public bool IsPublished { get; set; }
    }
}
