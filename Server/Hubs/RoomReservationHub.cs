using Common.Communication;
using Microsoft.AspNetCore.SignalR;
using Server.Server;

namespace Server.Hubs
{
    public class RoomReservationHub : Hub<IRoomReservationClient>, IRoomReservationHub
    {
        public RoomReservationHub(IClientRequestHandler clientRequestHandler)
        {
            ClientRequestHandler = clientRequestHandler;
        }

        public IClientRequestHandler ClientRequestHandler { get; }
    }
}