using Common.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IDtoToEntityConverter
    {
        Room ConvertRoomModel(IRoomDto roomModel);
        User ConvertUserModel(IUserDto userModel);
        Reservation ConvertReservationModel(IReservationDto reservationModel);
    }
}