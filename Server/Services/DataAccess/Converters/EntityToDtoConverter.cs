using Common.Data;
using Common.Dto;
using Common.Enums;
using DAL.DbEntities;
using System;
using System.Linq;

namespace Server.Services.DataAccess.Converters
{
    public class EntityToDtoConverter : IEntityToDtoConverter
    {
        #region Constructor

        public EntityToDtoConverter(Func<string, RoomLocation, int, bool, bool, IRoomDto> roomDtoFactory,
            Func<string, UserClearance, IUserDto> userDtoFactory,
            Func<int, DateTime, DateTime, IRoomDto, IUserDto, UserClearance, IReservationDto> reservationDtoFactory)
        {
            RoomDtoFactory = roomDtoFactory;
            UserDtoFactory = userDtoFactory;
            ReservationDtoFactory = reservationDtoFactory;
        }

        #endregion

        #region Implementation of IEntityToDtoConverter

        public IReservationDto ConvertReservationEntity(Reservation reservation)
        {
            var initiator = ConvertUserEntity(reservation.Initiator);
            return initiator.RoomReservations.Single(r => r.Id == reservation.Id);
        }

        public IRoomDto ConvertRoomEntity(Room room)
        {
            return RoomDtoFactory(room.Description,
                new RoomLocation(room.Building, room.Floor, room.Number),
                room.Capacity,
                room.HasSpeaker,
                room.HasComputer);
        }

        public IUserDto ConvertUserEntity(User user)
        {
            return UserDtoFactory(user.Username, user.UserClearance);
        }

        #endregion

        #region Private Members

        public IReservationDto ConvertReservationEntity(Reservation reservation, IUserDto userDto)
        {
            return ReservationDtoFactory(reservation.Id,
                reservation.StartTime,
                reservation.EndTime,
                ConvertRoomEntity(reservation.Room),
                userDto,
                reservation.RequiredClearance);
        }

        private Func<string, RoomLocation, int, bool, bool, IRoomDto> RoomDtoFactory { get; }
        private Func<string, UserClearance, IUserDto> UserDtoFactory { get; }
        private Func<int, DateTime, DateTime, IRoomDto, IUserDto, UserClearance, IReservationDto> ReservationDtoFactory { get; }

        #endregion
    }
}