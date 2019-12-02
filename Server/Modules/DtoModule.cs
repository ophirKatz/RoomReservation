using Autofac;
using Common.Dto;
using Common.Extensions;

namespace Server.Modules
{
    public class DtoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAllBySuffix(typeof(IRoomDto).Assembly, "Dto");
        }
    }
}