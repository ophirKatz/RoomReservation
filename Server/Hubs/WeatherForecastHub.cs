﻿using Common.Communication;
using Common.Extensions;
using Microsoft.AspNetCore.SignalR;
using Server.Server;
using System;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class WeatherForecastHub : Hub<IWeatherClient>, IWeatherForecastHub
    {
        public WeatherForecastHub(IClientRequestHandler clientRequestHandler)
        {
            ClientRequestHandler = clientRequestHandler;
        }

        public async Task GetForecastAsync(DateTime startDate)
        {
            var forecast = await ClientRequestHandler
                .GetForecastAsync(startDate)
                .ConfigureAwait(false);

            await Clients.Caller.ReceiveWeatherForecast(forecast);
        }

        public IClientRequestHandler ClientRequestHandler { get; }
    }
}