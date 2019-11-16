using Autofac;
using Server.Hubs;
using Server.Modules;
using Server.Server;

namespace Server
{
    public class Bootstrapper
    {
        public Bootstrapper(ContainerBuilder builder)
        {
            #region Register Modules

            builder.RegisterModule<ServiceModule>();

            #endregion

            #region Register Server

            builder.RegisterType<WeatherForecastHub>().AsSelf();
            builder.RegisterType<ClientRequestHandler>().As<IClientRequestHandler>().SingleInstance();

            #endregion
        }
    }
}