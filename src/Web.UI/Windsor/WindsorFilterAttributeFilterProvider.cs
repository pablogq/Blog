#region Libraries
using Castle.MicroKernel;
using Castle.Windsor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc; 
#endregion

namespace Blog.Web.UI.Windsor
{
    public class WindsorFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        private static readonly IDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> propertyCache = new Dictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly object cacheLock = new object();
        private readonly IWindsorContainer container;

        public WindsorFilterAttributeFilterProvider(IWindsorContainer container)
        {
            Guard.IsNotNull(container, "container");

            this.container = container;
        }

        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<FilterAttribute> attributes = base.GetControllerAttributes(controllerContext, actionDescriptor);
            this.InjectDependencies(attributes);
            return attributes;
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<FilterAttribute> attributes = base.GetActionAttributes(controllerContext, actionDescriptor);
            this.InjectDependencies(attributes);
            return attributes;
        }

        private void InjectDependencies(IEnumerable<FilterAttribute> attributes) 
        {
            attributes.ForEach(attribute =>
            {
                Properties(attribute.GetType(), this.container)
                    .ForEach(property => property.SetValue(attribute, this.container.Resolve(property.PropertyType), null));
            });
        }

        private static IEnumerable<PropertyInfo> Properties(Type type, IWindsorContainer container)
        {
            RuntimeTypeHandle typeHandle = type.TypeHandle;
            IEnumerable<PropertyInfo> properties;

            if (!propertyCache.TryGetValue(typeHandle, out properties))
            {
                lock (cacheLock)
                {
                    if (!propertyCache.TryGetValue(typeHandle, out properties))
                    {
                        Func<PropertyInfo, bool> filter = CreatePropertyFilter(container);

                        properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                                         .Where(filter);
                        propertyCache.Add(typeHandle, properties);
                    }
                }
            }
            return properties ?? Enumerable.Empty<PropertyInfo>();
        }

        private static Func<PropertyInfo, bool> CreatePropertyFilter(IWindsorContainer container)
        {
            return property =>
            {
                if (property.CanWrite)
                {
                    MethodInfo setMethod = property.GetSetMethod();
                    if (setMethod != null && setMethod.GetParameters().Length == 1)
                    {
                        if (container.Kernel.HasComponent(property.PropertyType))
                        {
                            return true;
                        }
                    }
                }
                return false;
            };
        }
    }
}
