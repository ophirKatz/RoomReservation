using Serilog;
using Shared.Communication;

namespace RoomResClient.Client
{
    public class RoomReservationClient : IRoomReservationClient
    {
        public RoomReservationClient(ILogger logger)
        {
            logger.Information("Started listening on server notifications");
        }
    }
}