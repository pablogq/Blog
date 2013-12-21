#region Libraries
using Blog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Domain.Services
{
    public interface IConfigurationDomainService
    {
        void Save(Configuration configuration);
        Configuration Get();
    }
}
