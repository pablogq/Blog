#region Libraries
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
    public abstract class LayoutController : Controller
    {
        private readonly IApplicationServices applicationServices;

        protected LayoutController(IApplicationServices applicationServices)
        {
            Guard.IsNotNull(applicationServices, "applicationServices");

            this.applicationServices = applicationServices;
        }

        protected IApplicationServices Services { get { return this.applicationServices; } }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ViewResultBase viewResult = filterContext.Result as ViewResultBase;
            if (viewResult.IsNull()) 
            {
                return;
            }

            if (viewResult.ViewData.Model.IsNull()) 
            {
                viewResult.ViewData.Model = new LayoutViewModel();
            }

            LayoutViewModel model = viewResult.ViewData.Model as LayoutViewModel;
            if (model.IsNull()) 
            {
                throw new InvalidCastException("View model must inherit LayoutModel in action: {0}".FormatWith(filterContext.ActionDescriptor.ActionName));
            }

            this.EnsureLayoutViewModelDependencies(model);
        }

        private void EnsureLayoutViewModelDependencies(LayoutViewModel viewModel) 
        {
            viewModel.User = this.Services.User.Current;
            viewModel.Configuration = this.Services.Configuration.Current;
        }
    }
}
