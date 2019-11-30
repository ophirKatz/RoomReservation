using DAL.DbEntities;
using System.Collections.Generic;

namespace DbFiller
{
    public interface IDataReader
    {
        IEnumerable<Room> GetRooms();
        IEnumerable<User> GetUsers();
        IEnumerable<Reservation> GetReservations();
    }
}