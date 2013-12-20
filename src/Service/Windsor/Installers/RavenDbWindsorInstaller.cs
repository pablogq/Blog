#region Libraries
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.WcfIntegration;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
#endregion

namespace Blog.Service.Windsor
{
    public class RavenDbWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDocumentStore>()
                                        .ImplementedBy<DocumentStore>()
                                        .DependsOn(new { connectionStringName = "RavenDB" })
                                        .OnCreate(Initialize)
                                        .LifeStyle.Singleton,
                               Component.For<IDocumentSession>()
                                        .UsingFactoryMethod(CreateDocumentSession)
                                        .OnDestroy(ReleaseDocumentSession)
                                        .LifeStyle.PerWcfOperation());
        }

        private static void Initialize(IKernel kernel, IDocumentStore store)
        {
            store.Initialize();
        }

        private static IDocumentSession CreateDocumentSession(IKernel kernel)
        {
            IDocumentStore store = kernel.Resolve<IDocumentStore>();
            return store.OpenSession();
        }

        private static void ReleaseDocumentSession(IKernel kernel, IDocumentSession session)
        {
            if (session.Advanced.HasChanges)
            {
                session.SaveChanges();
            }
        }
    }
}