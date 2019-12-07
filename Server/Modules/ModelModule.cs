using Autofac;
using Shared.Extensions;
using System.Reflection;

namespace Server.Modules
{
    public class ModelModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAllBySuffix(Assembly.GetExecutingAssembly(), "Model");
        }
    }
}