using Common.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IDtoToEntityConverter
    {
        Room ConvertRoomDto(RoomDto roomDto);
        User ConvertUserDto(UserDto userDto);
        Reservation ConvertReservationDto(ReservationDto reservationDto);
    }
}