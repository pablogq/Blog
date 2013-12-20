#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
#endregion

namespace Blog.Web.Model
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString Safe(this HtmlHelper html, string unsafeHtml)
        {
            return MvcHtmlString.Create(unsafeHtml);
        }
    }
}
