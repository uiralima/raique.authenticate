using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;

namespace AspNet.API
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IDependencyResolver _master;

        public DependencyResolver(System.Web.Http.Dependencies.IDependencyResolver master)
        {
            _master = master;
        }
        public IDependencyScope BeginScope()
        {
            return _master.BeginScope();
        }

        public void Dispose()
        {
            _master.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.FullName == typeof(IHttpControllerActivator).FullName)
            {
                return new ActivatorInternal();
            }
            return _master.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _master.GetServices(serviceType);
        }
    }
}