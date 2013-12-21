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
        [Required(ErrorMessage = "Por favor ingresar el título de la publicación.")]
        [DisplayName("Título")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Por favor ingresar el contendio.")]
        public string Content { get; set; }

        [DisplayName("Publicado?")]
        public bool IsPublished { get; set; }
    }
}
