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
            await Connection.InvokeAsync<Task>(nameof(IWeatherForecastHub.GetForecastAsync), startDate);
        }

        private HubConnection Connection { get; set; }
    }
}