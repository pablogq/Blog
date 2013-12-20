#region Libraries
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.WcfIntegration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
#endregion

namespace Blog.Service.Windsor.Installers
{
    public class ServiceWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn(KnownTypes.Service)
                                      .Configure(component => component.AsWcfService(new DefaultServiceModel().Hosted()))
                                      .LifestyleTransient());

            Predicate<AssemblyName> assemblyFilter = assembly => assembly.FullName.StartsWith("Blog.");
            Predicate<Type> typeFilter = type => type.Namespace.Contains("Infrastructure") || type.Namespace.Contains("Domain.Services");
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("bin").FilterByName(assemblyFilter))
                                      .Where(typeFilter)
                                      .WithServiceAllInterfaces()
                                      .LifestylePerWcfOperation());
        }
    }
}