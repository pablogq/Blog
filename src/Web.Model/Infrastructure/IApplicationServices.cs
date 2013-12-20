﻿#region Libraries
using Blog.Web.Model.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.Infrastructure
{
    public interface IApplicationServices
    {
        IUserProvider User { get; }
        IHttpContextProvider HttpContext { get; }
    }
}
