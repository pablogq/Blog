#region Libraries
using Blog.ServiceModel;
using Blog.Web.Model.Infrastructure.Configuration;
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
        IConfigurationProvider Configuration { get; }
        IMapper Mapper { get; }
        IClientFactory<IEntryClient> EntryService { get; }
    }
}
