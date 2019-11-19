using Common.Communication;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace BlazorPOC.Client
{
    public class ServerProxy : IServerProxy
    {
        public ServerProxy(HubConnection connection)
        {
            Connection = connection;
            Connection.StartAsync();
        }

        public async Task GetForecastAsync(DateTime startDate)
        {
            await Connection.InvokeAsync<Task>(nameof(IWeatherForecastHub.GetForecastAsync),
                startDate);
        }

        public async Task SetWeatherServerName(string name, int index)
        {
            await Connection.InvokeAsync<Task>(nameof(IWeatherForecastHub.SetWeatherServerName),
                name,
                index);
        }

        private HubConnection Connection { get; set; }
    }
}