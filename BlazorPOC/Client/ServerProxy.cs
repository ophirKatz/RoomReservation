using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorPOC.Client
{
    public class ServerProxy : IServerProxy
    {
        public ServerProxy(HubConnection connection)
        {
            Connection = connection;
            Connection.StartAsync();
        }

        private HubConnection Connection { get; set; }
    }
}