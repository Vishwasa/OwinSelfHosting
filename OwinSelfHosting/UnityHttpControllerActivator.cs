using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Unity;

namespace OwinSelfHosting
{
    internal class UnityHttpControllerActivator : IHttpControllerActivator
    {
        private UnityContainer _container;

        public UnityHttpControllerActivator(UnityContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_container.Resolve(controllerType);
        }
    }
}