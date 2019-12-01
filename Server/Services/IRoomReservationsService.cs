using System;
using System.Collections.Generic;
using Common.Dto;

namespace Server.Services
{
    public interface IRoomReservationsService
    {
        List<IUserDto> GetAllUsers();
        List<IRoomDto> GetAllRooms();
        List<IRoomDto> GetAllAvailableRooms();
        List<IRoomDto> GetAllAvailableRooms(DateTime startTime);
        List<IRoomDto> GetAllAvailableRooms(DateTime startTime, DateTime endTime);
    }
}