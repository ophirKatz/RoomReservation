using Autofac;
using Server.Modules;

namespace Server
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            var builder = new ContainerBuilder();

            #region Load Modules

            builder.RegisterModule<ServiceModule>();

            #endregion

            var container = builder.Build();
        }

        
    }
}