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
            builder.RegisterAllBySuffix(assembly, "Service");
            builder.RegisterAllBySuffix(assembly, "Converter");
            builder.RegisterType<RoomReservationsContainer>().As<IRoomReservationsContainer>().SingleInstance();
        }
    }
}