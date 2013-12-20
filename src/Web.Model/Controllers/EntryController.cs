#region Libraries
using Blog.ServiceModel;
using Blog.Web.Model.Infrastructure;
using Blog.Web.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#endregion

namespace Blog.Web.Model.Controllers
{
    public class EntryController : LayoutController
    {
        public EntryController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }

        [HttpGet]
        public ActionResult Show([Bind(Prefix = "id")] string slug) 
        {
            Guard.IsNotNullOrEmpty(slug, "slug");

            EntryContract entry = this.Services.EntryService.Get(client => client.Get(slug));
            if (entry.IsNull()) 
            {
                return this.HttpNotFound("Entry not found");
            }

            EntryViewModel model = this.Services.Mapper.Map<EntryViewModel, EntryContract>(entry);
            return this.View(model);
        }
    }
}
