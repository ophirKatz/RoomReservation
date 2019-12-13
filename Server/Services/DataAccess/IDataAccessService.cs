using DAL.DbEntities;
using Server.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services.DataAccess
{
    public interface IDataAccessService
    {
        bool TryGetRoomByDescription(string description, out Room room);
        bool TryGetUserByName(string username, out User user);
        Task<List<Reservation>> GetUserReservationsAsync(string username);
        Task<List<Reservation>> GetReservationsForRoomAsync(string description);
        Task<List<Room>> GetAllRoomsAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<bool> SaveReservation(IReservationModel reservationModel);
    }
}