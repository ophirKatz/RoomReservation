using Autofac;
using Server.Modules;

namespace Server
{
    public class Bootstrapper
    {
        public Bootstrapper(ContainerBuilder builder)
        {
            #region Register Modules

            builder.RegisterModule<ServiceModule>();

            #endregion
        }
    }
}