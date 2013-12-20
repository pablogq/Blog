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

        [HttpGet, AdminOnly]
        public ActionResult Create() 
        {
            return this.View("Edit", new EditorViewModel());
        }

        [HttpPost, AdminOnly, ValidateAntiForgeryToken]
        public ActionResult Create(EditorViewModel model) 
        {
            string slug = model.Title.ToUrlSlug();

            EntryContract existintEntry = this.Services.EntryService.Get(client => client.Get(slug));
            if (existintEntry.IsNotNull()) 
            {
                this.ModelState.AddModelError("Title", "Sorry, a post already exists with the slug '{0}', please change the title.".FormatWith(slug));
            }

            if (!this.ModelState.IsValid) 
            {
                return this.View("Edit", model);
            }

            model.Slug = slug;
            return this.Save(model, true) ? this.RedirectToAction("Show", "Entry", new { id = slug }) : this.View("Edit", model) as ActionResult;
        }

        [HttpGet, AdminOnly]
        public ActionResult Edit([Bind(Prefix="id")] string slug) 
        {
            EntryContract entry = this.Services.EntryService.Get(client => client.Get(slug));
            if (entry.IsNull())
            {
                return this.HttpNotFound("Entry not found");
            }

            EditorViewModel model = this.Services.Mapper.Map<EditorViewModel, EntryContract>(entry);
            return this.View(model);
        }

        [HttpPost, AdminOnly, ValidateAntiForgeryToken]
        public ActionResult Edit(EditorViewModel model) 
        {
            if (model.Slug.IsNullOrEmpty())
            {
                this.ModelState.AddModelError("Error", "The slug was not found, the entry was not updated.");
            }

            if (!this.ModelState.IsValid) 
            {
                return this.View(model);
            }

            return this.Save(model) ? this.RedirectToAction("Show", "Entry", new { id = model.Slug }) : this.View("Edit", model) as ActionResult;
        }

        [HttpPost, AdminOnly, ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteViewModel model) 
        {
            if (model.Slug.IsNullOrEmpty())
            {
                this.ModelState.AddModelError("Error", "The slug was not found, the entry was not deleted.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Response response = this.Services.EntryService.Get(client => client.Delete(model.Slug));
            if (!response.Success)
            {
                this.ModelState.AddModelError("Error", "There was a problem posting the entry.");
                return this.View("Delete", model);
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet, AdminOnly]
        public ActionResult Delete([Bind(Prefix = "id")] string slug) 
        {
            EntryContract entry = this.Services.EntryService.Get(client => client.Get(slug));
            if (entry.IsNull())
            {
                return this.HttpNotFound("Entry not found");
            }

            DeleteViewModel model = this.Services.Mapper.Map<DeleteViewModel, EntryContract>(entry);
            return this.View(model);
        }

        private bool Save(EditorViewModel model, bool creating = false)
        {
            EntryContract entry = this.Services.Mapper.Map<EntryContract, EditorViewModel>(model);
            entry.Author = this.Services.User.Current.FriendlyName;
            if (creating) 
            {
                entry.CreatedAt = DateTime.Now;
            }
            Response response = this.Services.EntryService.Get(client => client.Save(entry));
            if (!response.Success)
            {
                this.ModelState.AddModelError("Error", "There was a problem posting the entry.");
            }

            return response.Success;
        }
    }
}
