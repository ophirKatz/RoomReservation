using DAL.DbEntities;
using Server.Model;

namespace Server.Services.DataAccess.Converters
{
    public interface IModelToEntityConverter
    {
        Room ConvertRoomModel(IRoomModel roomModel);
        User ConvertUserModel(IUserModel userModel);
        Reservation ConvertReservationModel(IDataAccessService dataAccessService, IReservationModel reservationModel);
    }
}