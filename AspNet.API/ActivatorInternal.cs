using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace AspNet.API
{
    public class ActivatorInternal : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return Raique.DependencyInjection.Repository.CreateInstance(controllerDescriptor.ControllerType.FullName) as IHttpController;
        }
    }
}