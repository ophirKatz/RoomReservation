using DAL.DbEntities;
using Server.Model;

namespace Server.Services.DataAccess.Converters
{
    public class ModelToEntityConverter : IModelToEntityConverter
    {
        #region Implementation of IDtoToEntityConverter

        public Reservation ConvertReservationModel(IDataAccessService dataAccessService, IReservationModel reservationModel)
        {
            if (!dataAccessService.TryGetRoomByDescription(reservationModel.Room.Description, out var room) ||
                !dataAccessService.TryGetUserByName(reservationModel.Initiator.Name, out var user))
            {
                return null;
            }
            var roomId = room.Id;
            var initiatorId = user.Id;

            return new Reservation
            {
                StartTime = reservationModel.StartTime,
                EndTime = reservationModel.EndTime,
                RequiredClearance = reservationModel.RequiredClearance,
                RoomId = roomId,
                InitiatorId = initiatorId
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
            return new User
            {
                Username = userModel.Name,
                UserClearance = userModel.UserClearance
            };
        }

        #endregion
    }
}