using Autofac;
using Microsoft.Extensions.Configuration;
using RoomResClient.Configuration;
using RoomResClient.UI.Localization;
using System.Collections.Generic;
using System.IO;

namespace RoomResClient.Modules
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var stringResourcePath = Path.Combine("UI", "Localization", "StringResource.json");
            var stringResourceValues = new ConfigurationBuilder()
                .AddJsonFile(stringResourcePath)
                .Build()
                .Get<Dictionary<string, string>>();

            builder.RegisterInstance(new ResourceManager(stringResourceValues))
                .As<IResourceManager>()
                .As<IStringResourceManager>();
        }
    }
}