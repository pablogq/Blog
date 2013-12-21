#region Libraries
using Blog.Web.Model.Infrastructure;
using Blog.Web.Model.Infrastructure.Security;
using Blog.Web.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
#endregion

namespace Blog.Web.Model.Controllers
{
    public class AuthenticationController : LayoutController
    {
        private readonly IFormsAuthentication formsAuthentication;
        private readonly IAuthenticator authenticator;

        public AuthenticationController(IApplicationServices applicationServices, IFormsAuthentication formsAuthentication, IAuthenticator authenticator)
            : base(applicationServices)
        {
            Guard.IsNotNull(formsAuthentication, "formsAuthentication");
            Guard.IsNotNull(authenticator, "authenticator");

            this.formsAuthentication = formsAuthentication;
            this.authenticator = authenticator;
        }



        [HttpGet]
        public ActionResult Login(LoginViewModel model)
        {
            model.ReturnUrl = this.ResolveReturnUrl(model.ReturnUrl);
            if (this.authenticator.Authenticate(model.Token))
            {
                this.formsAuthentication.SetAuthenticationCookie("pablogq", true, "Pablo Guerrero");
                return this.Redirect(model.ReturnUrl);
            }

            model.Message = "Acceso denegado!";
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Logout(string returnUrl = null) 
        {
            this.formsAuthentication.SignOut();

            returnUrl = this.ResolveReturnUrl(returnUrl);
            return this.Redirect(returnUrl);
        }

        private string ResolveReturnUrl(string returnUrl)
        {
            if (returnUrl.IsNotNullOrEmpty())
            {
                return returnUrl;
            }
            return this.Url.Action("Index", "Home");
        }
    }
}
