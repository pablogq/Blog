﻿#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Security
{
    public interface IAuthenticator
    {
        bool Authenticate(string token);
    }
}
