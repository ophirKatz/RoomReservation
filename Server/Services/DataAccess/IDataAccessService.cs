using Common.Model;
using DAL.DbEntities;
using System.Collections.Generic;

namespace Server.Services.DataAccess
{
    public interface IDataAccessService
    {
        bool TryGetRoomByDescription(string description, out Room room);
        bool TryGetUserByName(string username, out User user);
        List<Reservation> GetUserReservations(string username);
        List<Reservation> GetReservationsForRoom(string description);
        List<Room> GetAllRooms();
        List<User> GetAllUsers();
    }
}