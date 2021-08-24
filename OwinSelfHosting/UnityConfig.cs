using Serilog;
using System;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace OwinSelfHosting
{
    internal class UnityConfig
    {
        internal static void RegisterComponents(UnityContainer container)
        {
            try
            {
                var logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
                container.RegisterType<ILogger>(new ContainerControlledLifetimeManager(), new InjectionFactory((ctr, type, name) =>
                {
                    var log = logger;
                    return log;
                }));
            }
            catch
            {
                Log.Error("Error in UnityConfig Ex");
            }
        }
    }
}