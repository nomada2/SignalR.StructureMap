using System;
using System.Collections.Generic;
using StructureMap;
using SignalR.Infrastructure;

namespace SignalR.Ninject 
{
    public class StructureMapDependencyResolver : DefaultDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container) 
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        public override object GetService(Type serviceType) 
        {
            return _container.GetInstance(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType) 
        {
            return _container.GetAllInstances(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}
