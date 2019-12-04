using Autofac;
using Common.Dto;

namespace Server.Modules
{
    public class DtoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomDto>().AsSelf();
            builder.RegisterType<UserDto>().AsSelf();
            builder.RegisterType<ReservationDto>().AsSelf();
            /*var assembly = typeof(RoomDto).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Dto"))
                .AsSelf();*/
        }
    }
}