using Shared.Dto;
using System.Collections.Generic;

namespace Server.Server
{
    public interface IClientRequestHandler
    {
        // TODO : Add all client commands. This class will be injected with services that can handle these commands
        List<UserDto> GetAllUsers();
        List<RoomDto> GetAllRooms();
        bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription);
    }
}