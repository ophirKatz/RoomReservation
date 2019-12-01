using Common.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public interface IEntityToDtoConverter
    {
        IRoomDto ConvertRoomEntity(Room room);
        IUserDto ConvertUserEntity(User user);
        IReservationDto ConvertReservationEntity(Reservation reservation);
    }
}