using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;

namespace OwinSelfHosting
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            //config.Services.Replace(typeof(IAssembliesResolver), new controllerassembliesResolver)
            ConfigureIOCContainer(config);
            ConfigureFormatters(config);
            ConfigureRoutes(config);
            AutoMapperConfig.Config();//Need to be completed

            appBuilder.UseWebApi(config);
            SwaggerConfig.Configure(config);
            config.EnsureInitialized();

        }

        private void ConfigureFormatters(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureIOCContainer(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));
            UnityConfig.RegisterComponents(container);
        }

        private void ConfigureRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
