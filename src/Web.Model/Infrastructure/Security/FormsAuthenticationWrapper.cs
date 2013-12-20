#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public class FormsAuthenticationWrapper : IFormsAuthentication
    {
        private readonly IHttpContextProvider httpContext;

        public FormsAuthenticationWrapper(IHttpContextProvider httpContext)
        {
            Guard.IsNotNull(httpContext, "httpContext");

            this.httpContext = httpContext;
        }

        public string LoginUrl { get { return FormsAuthentication.LoginUrl; } }

        public void SetAuthenticationCookie(string userName, bool createPersistentCookie, string userData)
        {
            Guard.IsNotNullOrEmpty(userName, "userName");
            double timeout = FormsAuthentication.Timeout.TotalMinutes;
            DateTime expiry = DateTime.Now.AddMinutes(timeout);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                                                                             userName,
                                                                             DateTime.Now,
                                                                             expiry,
                                                                             createPersistentCookie,
                                                                             userData,
                                                                             FormsAuthentication.FormsCookiePath);

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
            {
                Value = encryptedTicket,
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL
            };

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            this.httpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
