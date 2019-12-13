using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomResClient.Client
{
    public interface IServerProxy : IDisposable
    {
        // TODO : Add all server proxy calls - these call to the hub methods via HubConnection object
        Task<List<UserDto>> GetAllUsers();
        Task<List<RoomDto>> GetAllRooms();
        Task<bool> AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription);
    }
}