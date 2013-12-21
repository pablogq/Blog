#region Libraries
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.ViewModels
{
    public class ConfigurationViewModel : LayoutViewModel
    {
        [Required(ErrorMessage = "Por favor ingresar el nombre del blog.")]
        [DisplayName("Nombre del blog")]
        public string Title { get; set; }
        [DisplayName("Administradores")]
        public string Admins { get; set; }
        [DisplayName("Cabecera")]
        public string Heading { get; set; }
        public string Twitter { get; set; }
        [DisplayName("Meta descripción")]
        public string MetaDescription { get; set; }
    }
}
