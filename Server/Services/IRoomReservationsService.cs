using System;
using System.Collections.Generic;
using Shared.Dto;

namespace Server.Services
{
    public interface IRoomReservationsService
    {
        List<UserDto> GetAllUsers();
        List<RoomDto> GetAllRooms();
        List<RoomDto> GetAllAvailableRooms();
        List<RoomDto> GetAllAvailableRooms(DateTime startTime);
        List<RoomDto> GetAllAvailableRooms(DateTime startTime, DateTime endTime);
    }
}