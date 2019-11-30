using System;
using System.Collections.Generic;
using Common.Model;

namespace Server.Services
{
    public interface IRoomReservationsService
    {
        List<IUserModel> GetAllUsers();
        List<IRoomModel> GetAllRooms();
        List<IRoomModel> GetAllAvailableRooms();
        List<IRoomModel> GetAllAvailableRooms(DateTime startTime);
        List<IRoomModel> GetAllAvailableRooms(DateTime startTime, DateTime endTime);
    }
}