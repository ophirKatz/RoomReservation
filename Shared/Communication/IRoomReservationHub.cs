using Shared.Dto;
using System.Collections.Generic;

namespace Shared.Communication
{
    public interface IRoomReservationHub
    {
        // TODO : Add all server requests here
        List<UserDto> GetAllUsers();
        List<RoomDto> GetAllRooms();
        bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription);
    }
}