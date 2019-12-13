using Server.Model;
using Shared.Dto;
using System;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IRoomReservationsService
    {
        List<IUserModel> GetAllUsers();
        List<IRoomModel> GetAllRooms();
        List<IRoomModel> GetAllAvailableRooms();
        List<IRoomModel> GetAllAvailableRooms(DateTime startTime);
        List<IRoomModel> GetAllAvailableRooms(DateTime startTime, DateTime endTime);
        bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription);
    }
}