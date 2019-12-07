using DAL.DbEntities;
using Server.Model;
using Shared.Data;

namespace Server.Services.DataAccess.Converters
{
    public class EntityToModelConverter : IEntityToModelConverter
    {
        #region Constructor

        /*public EntityToModelConverter(Func<string, RoomLocation, int, bool, bool, IRoomModel> roomModelFactory,
            Func<string, UserClearance, IUserModel> userModelFactory,
            Func<int, DateTime, DateTime, IRoomModel, IUserModel, UserClearance, IReservationModel> reservationModelFactory)*/
        public EntityToModelConverter(IRoomModel.Factory roomModelFactory,
            IUserModel.Factory userModelFactory,
            IReservationModel.Factory reservationModelFactory)
        {
            RoomModelFactory = roomModelFactory;
            UserModelFactory = userModelFactory;
            ReservationModelFactory = reservationModelFactory;
        }

        #endregion

        #region Implementation of IEntityToDtoConverter

        public IReservationModel ConvertReservationEntity(Reservation reservation)
        {
            var room = ConvertRoomEntity(reservation.Room);
            var initiator = ConvertUserEntity(reservation.Initiator);

            return ReservationModelFactory(reservation.Id,
                reservation.StartTime,
                reservation.EndTime,
                room,
                initiator,
                reservation.RequiredClearance);
        }

        public IRoomModel ConvertRoomEntity(Room room)
        {
            return RoomModelFactory(room.Description,
                new RoomLocation(room.Building, room.Floor, room.Number),
                room.Capacity,
                room.HasSpeaker,
                room.HasComputer);
        }

        public IUserModel ConvertUserEntity(User user)
        {
            return UserModelFactory(user.Username, user.UserClearance);
        }

        #endregion

        #region Private Members

        private IRoomModel.Factory RoomModelFactory { get; }
        private IUserModel.Factory UserModelFactory { get; }
        private IReservationModel.Factory ReservationModelFactory { get; }

        #endregion
    }
}