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
    public class AuthenticationController : LayoutController
    {
        public AuthenticationController(IApplicationServices applicationServices)
            : base(applicationServices)
        { }

        public ActionResult Login(string returnUrl = null) 
        {
            if (this.Request.IsAuthenticated)
            {
                return this.RedirectFromLogin(returnUrl);
            }

            return this.View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return this.View();
        }

        private ActionResult RedirectFromLogin(string returnUrl)
        {
            if (returnUrl.IsNullOrEmpty())
            {
                return this.RedirectToAction("", "");
            }
            return this.Redirect(returnUrl);
        }
    }
}
