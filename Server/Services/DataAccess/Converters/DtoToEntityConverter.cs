using Common.Model;
using DAL.DbEntities;
using System.Linq;

namespace Server.Services.DataAccess.Converters
{
    public class DtoToEntityConverter : IDtoToEntityConverter
    {
        #region Constructor

        public DtoToEntityConverter(IDataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }

        #endregion

        #region Implementation of IDtoToEntityConverter

        public Reservation ConvertReservationModel(IReservationModel reservationModel)
        {
            if (!DataAccessService.TryGetRoomByDescription(reservationModel.Room.Description, out var room))
            {
                room = ConvertRoomModel(reservationModel.Room);
            }

            if (!DataAccessService.TryGetUserByName(reservationModel.Initiator.Name, out var user))
            {
                user = ConvertUserModel(reservationModel.Initiator);
            }

            return new Reservation
            {
                StartTime = reservationModel.StartTime,
                EndTime = reservationModel.EndTime,
                RequiredClearance = reservationModel.RequiredClearance,
                Room = room,
                Initiator = user
            };
        }

        public Room ConvertRoomModel(IRoomModel roomModel)
        {
            return new Room
            {
                Description = roomModel.Description,
                Building = roomModel.Location.Building,
                Floor = roomModel.Location.Floor,
                Number = roomModel.Location.Number,
                Capacity = roomModel.Capacity,
                HasSpeaker = roomModel.HasSpeaker,
                HasComputer = roomModel.HasComputer
            };
        }

        public User ConvertUserModel(IUserModel userModel)
        {
            var reservations = DataAccessService.GetUserReservations(userModel.Name);
            if (reservations == null)
            {
                reservations = userModel.RoomReservations.Select(res => ConvertReservationModel(res)).ToList();
            }

            return new User
            {
                Username = userModel.Name,
                UserClearance = userModel.UserClearance,
                Reservations = reservations
            };
        }

        #endregion

        #region Private Members

        public IDataAccessService DataAccessService { get; }

        #endregion
    }
}