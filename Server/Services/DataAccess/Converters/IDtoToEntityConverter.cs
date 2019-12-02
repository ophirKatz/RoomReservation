using Common.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IDtoToEntityConverter
    {
        Room ConvertRoomDto(IRoomDto roomDto);
        User ConvertUserDto(IUserDto userDto);
        Reservation ConvertReservationDto(IReservationDto reservationDto);
    }
}