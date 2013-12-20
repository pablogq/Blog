#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc; 
#endregion

namespace Blog.Web.Model.Infrastructure
{
    public class AdminOnlyAttribute : FilterAttribute, IAuthorizationFilter
    {
        private IApplicationServices services;
        private readonly bool authorize;

        public AdminOnlyAttribute()
            : this(true)
        { }

        public AdminOnlyAttribute(bool authorize)
        {
            this.authorize = authorize;
        }

        public IApplicationServices Services 
        {
            get { return this.services; }
            set 
            {
                Guard.IsNotNull(value, "services");

                this.services = value;
            }
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Guard.IsNotNull(filterContext, "filterContext");

            if (this.Authorize(filterContext.HttpContext)) 
            {
                HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
                cache.SetProxyMaxAge(new TimeSpan(0L));
                cache.AddValidationCallback(this.CacheValidateHandler, null);
            }
        }

        protected virtual bool Authorize(HttpContextBase httpContext) 
        {
            Guard.IsNotNull(httpContext, "httpContext");

            if (!this.authorize) 
            {
                return true;
            }
            //return this.Services.User.Current.IsAdmin;
            return true;
        }

        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext) 
        {
            Guard.IsNotNull(httpContext, "httpContext");

            if (!this.Authorize(httpContext)) 
            {
                return HttpValidationStatus.IgnoreThisRequest;
            }
            return HttpValidationStatus.Valid;
        }

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext context) 
        {
            context.Result = new HttpUnauthorizedResult();
        }

        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        }
    }
}
