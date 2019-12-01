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

        public EntityToDtoConverter(Func<string, RoomLocation, int, bool, bool, IRoomDto> roomModelFactory,
            Func<string, UserClearance, IUserDto> userModelFactory,
            Func<int, DateTime, DateTime, IRoomDto, IUserDto, UserClearance, IReservationDto> reservationModelFactory)
        {
            RoomModelFactory = roomModelFactory;
            UserModelFactory = userModelFactory;
            ReservationModelFactory = reservationModelFactory;
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
            return RoomModelFactory(room.Description,
                new RoomLocation(room.Building, room.Floor, room.Number),
                room.Capacity,
                room.HasSpeaker,
                room.HasComputer);
        }

        public IUserDto ConvertUserEntity(User user)
        {
            var userModel = UserModelFactory(user.Username, user.UserClearance);
            userModel.RoomReservations = user.Reservations
                .Select(r => ConvertReservationEntity(r, userModel))
                .ToList();

            return userModel;
        }

        #endregion

        #region Private Members

        public IReservationDto ConvertReservationEntity(Reservation reservation, IUserDto userModel)
        {
            return ReservationModelFactory(reservation.Id,
                reservation.StartTime,
                reservation.EndTime,
                ConvertRoomEntity(reservation.Room),
                userModel,
                reservation.RequiredClearance);
        }

        private Func<string, RoomLocation, int, bool, bool, IRoomDto> RoomModelFactory { get; }
        private Func<string, UserClearance, IUserDto> UserModelFactory { get; }
        private Func<int, DateTime, DateTime, IRoomDto, IUserDto, UserClearance, IReservationDto> ReservationModelFactory { get; }

        #endregion
    }
}