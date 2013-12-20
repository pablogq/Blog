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
#endregion

namespace Blog.Web.UI.Windsor.Installers
{
    public class ServiceModelWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Classes.FromAssembly(KnownAssemblies.ServiceModel)
            //                          .BasedOn(KnownTypes.ClientFactory)
            //                          .Configure(component => component.AsFactory())
            //                          .LifestylePerWebRequest());
            container.Register(Component.For(KnownTypes.ClientFactory)
                                        .AsFactory()
                                        .LifestylePerWebRequest(),
                               Component.For<IEntryClient>()
                                        .UsingFactoryMethod(ctx => SoapClientBase<IEntryClient>.Create("http://localhost:57742/Entry.svc"))
                                        .LifestyleTransient());
        }
    }
}