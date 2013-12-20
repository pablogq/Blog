#region Libraries
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web; 
#endregion

namespace Blog.Service.Windsor
{
    public class BlogServiceHostFactory : DefaultServiceHostFactory
    {
        public BlogServiceHostFactory()
            : base(BlogServiceHostFactory.CreateKernel())
        { }

        private static IKernel CreateKernel()
        {
            IWindsorContainer container = new WindsorContainer();
            container.AddFacility<WcfFacility>();
            container.Install(FromAssembly.This());
            return container.Kernel;
        }
    }
}