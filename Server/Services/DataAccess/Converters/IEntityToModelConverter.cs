using DAL.DbEntities;
using Server.Model;

namespace Server.Services.DataAccess.Converters
{
    public interface IEntityToModelConverter
    {
        IRoomModel ConvertRoomEntity(Room room);
        IUserModel ConvertUserEntity(User user);
        IReservationModel ConvertReservationEntity(Reservation reservation);
    }
}