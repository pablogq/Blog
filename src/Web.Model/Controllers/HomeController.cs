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
    public class HomeController : LayoutController
    {
        public HomeController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }

        [HttpGet]
        public ActionResult Index() 
        {
            IEnumerable<EntryContract> entries = this.Services.EntryService.Get(client => client.List());

            HomeViewModel model = new HomeViewModel
            {
                Entries = entries.OrderByDescending(e => e.CreatedAt)
                                 .Take(5)
                                 .Select(this.Services.Mapper.Map<EntrySummaryViewModel, EntryContract>)
                                 .ToList()
            };
            this.ViewBag.Message = "Artículos Recientes";
            return this.View(model);
        }
    }
}
