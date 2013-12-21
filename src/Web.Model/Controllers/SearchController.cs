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
    public class SearchController : LayoutController
    {
        public SearchController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }

        [HttpPost]
        public ActionResult Index(string criteria) 
        {
            IEnumerable<EntryContract> entries = this.Services.EntryService.Get(client => client.List());

            HomeViewModel model = new HomeViewModel
            {
                Entries = entries.Where(e => e.Title.Contains(criteria) || e.Content.Contains(criteria))
                                 .OrderByDescending(e => e.CreatedAt)
                                 .Select(this.Services.Mapper.Map<EntrySummaryViewModel, EntryContract>)
                                 .ToList()
            };
            this.ViewBag.Message = "Resultados para '{0}'".FormatWith(criteria);
            return this.View(model);
        }
    }
}
