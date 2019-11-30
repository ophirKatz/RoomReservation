using Common.Model;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IDtoToEntityConverter
    {
        Room ConvertRoomModel(IRoomModel roomModel);
        User ConvertUserModel(IUserModel userModel);
        Reservation ConvertReservationModel(IReservationModel reservationModel);
    }
}