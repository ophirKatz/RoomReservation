using Autofac;
using Server.Services;
using Shared.Extensions;
using System.Reflection;

namespace Server.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAllBySuffixSingleInstance(assembly, "Service");
            builder.RegisterAllBySuffixSingleInstance(assembly, "Converter");
            builder.RegisterType<RoomReservationsContainer>().As<IRoomReservationsContainer>().SingleInstance();
        }
    }
}