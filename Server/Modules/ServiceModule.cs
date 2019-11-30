using Autofac;
using Server.Services;
using Server.Services.DataAccess;

namespace Server.Modules
{
    class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataAccessService>()
                .As<IDataAccessService>();
        }
    }
}