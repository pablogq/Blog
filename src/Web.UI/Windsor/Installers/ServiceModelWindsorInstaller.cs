#region Libraries
using Blog.ServiceModel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.ServiceModel.Soap;
using Castle.MicroKernel;
using Blog.Web.Model.Infrastructure.Configuration;
using System.ServiceModel;
#endregion

namespace Blog.Web.UI.Windsor.Installers
{
    public class ServiceModelWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(KnownTypes.ClientFactory)
                                        .AsFactory()
                                        .LifestylePerWebRequest(),
                               Component.For<IEntryClient>()
                                        .UsingFactoryMethod(ctx => SoapClientBase<IEntryClient>.Create(String.Concat(GetEndpoint(ctx), "/Entry.svc")))
                                        .LifestyleTransient(),
                               Component.For<IConfigurationClient>()
                                        .UsingFactoryMethod(ctx => SoapClientBase<IConfigurationClient>.Create(String.Concat(GetEndpoint(ctx), "/Configuration.svc")))
                                        .LifestyleTransient());
        }

        private static string GetEndpoint(IKernel kernel)
        {
            IConfigurationManager configurationManager = kernel.Resolve<IConfigurationManager>();
            return configurationManager.AppSettings["endpoint"];
        }
    }
}