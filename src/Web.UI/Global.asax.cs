#region Libraries
using Blog.Web.Model.Controllers;
using Blog.Web.UI.Windsor;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing; 
#endregion

namespace Blog.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container;
        public MvcApplication()
        {
            this.container = new WindsorContainer().Install(FromAssembly.This());
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string[] namespaces = new[] { typeof(LayoutController).Namespace };

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Authentication", action = "Login" },
                constraints: new { httpMethod = new HttpMethodConstraint("GET", "POST") },
                namespaces: namespaces);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(this.container));
        }

        public override void Dispose()
        {
            this.container.Dispose();
            base.Dispose();
        }
    }
}