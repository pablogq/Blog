#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    public interface IConfigurationProvider
    {
        BlogConfiguration Current { get; }
    }
}
