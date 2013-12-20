#region Libraries
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web; 
#endregion

namespace Blog.Web.UI.Windsor.Installers
{
    public class WebWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Classes.FromAssembly(KnownAssemblies.WebModel)
                                      .BasedOn(KnownTypes.Controller)
                                      .LifestyleTransient());

            Predicate<AssemblyName> assemblyFilter = assembly => assembly.FullName.StartsWith("Blog.");
            Predicate<Type> typeFilter = type => type.Namespace.Contains("Infrastructure");
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("bin").FilterByName(assemblyFilter))
                                      .Where(typeFilter)
                                      .WithServiceAllInterfaces()
                                      .LifestylePerWebRequest());
        }
    }
}