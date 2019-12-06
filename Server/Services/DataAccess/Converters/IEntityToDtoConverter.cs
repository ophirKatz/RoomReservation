using Shared.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IEntityToDtoConverter
    {
        RoomDto ConvertRoomEntity(Room room);
        UserDto ConvertUserEntity(User user);
        ReservationDto ConvertReservationEntity(Reservation reservation);
    }
}