using Common.Data;
using Common.Dto;
using DAL.DbEntities;

namespace Server.Services.DataAccess.Converters
{
    public class EntityToDtoConverter : IEntityToDtoConverter
    {
        #region Implementation of IEntityToDtoConverter

        public ReservationDto ConvertReservationEntity(Reservation reservation)
        {
            var room = ConvertRoomEntity(reservation.Room);
            var initiator = ConvertUserEntity(reservation.Initiator);

            return new ReservationDto(reservation.Id,
                reservation.StartTime,
                reservation.EndTime,
                room,
                initiator,
                reservation.RequiredClearance);
        }

        public RoomDto ConvertRoomEntity(Room room)
        {
            return new RoomDto(room.Description,
                new RoomLocation(room.Building, room.Floor, room.Number),
                room.Capacity,
                room.HasSpeaker,
                room.HasComputer);
        }

        public UserDto ConvertUserEntity(User user)
        {
            return new UserDto(user.Username, user.UserClearance);
        }

        #endregion
    }
}