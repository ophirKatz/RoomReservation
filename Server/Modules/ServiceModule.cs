﻿using Autofac;
using Server.Services;

namespace Server.Modules
{
    class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataAccessService>()
                .As<IDataAccessService>();

            builder.RegisterType<WeatherForecastService>()
                .As<IWeatherForecastService>()
                .SingleInstance();
        }
    }
}