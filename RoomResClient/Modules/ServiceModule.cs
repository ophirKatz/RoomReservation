using Autofac;
using Microsoft.AspNetCore.Components.Authorization;
using RoomResClient.Client.Services;

namespace RoomResClient.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAuthenticationStateProvider>().As<AuthenticationStateProvider>();
            builder.RegisterType<UserAuthService>().As<IUserAuthService>();
        }
    }
}