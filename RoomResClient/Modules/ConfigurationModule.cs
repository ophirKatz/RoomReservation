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
            var stringResourceConfig = new ConfigurationBuilder()
                .AddJsonFile(stringResourcePath)
                .Build();

            var stringResourceValues = stringResourceConfig.GetSection("Strings").Get<Dictionary<string, string>>();
            var styles = stringResourceConfig.GetSection("Styles").Get<Dictionary<string, string>>();

            builder.RegisterInstance(new ResourceManager(stringResourceValues, styles))
                .As<IResourceManager>()
                .As<IStringResourceManager>()
                .As<IStylingResourceManager>()
                .SingleInstance();
        }
    }
}