using Server.Model;
using Shared.Dto;

namespace Server.Server.Converters
{
    public class ModelToDtoConverter : IModelToDtoConverter
    {
        #region Implementation of IModelToDtoConverter

        public ReservationDto ConvertReservationModelToDto(IReservationModel reservationModel)
        {
            var room = ConvertRoomModelToDto(reservationModel.Room);
            var initiator = ConvertUserModelToDto(reservationModel.Initiator);
            return new ReservationDto(reservationModel.Id,
                reservationModel.StartTime,
                reservationModel.EndTime,
                room,
                initiator,
                reservationModel.RequiredClearance);
        }

        public RoomDto ConvertRoomModelToDto(IRoomModel roomModel)
        {
            return new RoomDto(roomModel.Description,
                roomModel.Location,
                roomModel.Capacity,
                roomModel.HasSpeaker,
                roomModel.HasComputer);
        }

        public UserDto ConvertUserModelToDto(IUserModel userModel)
        {
            return new UserDto(userModel.Name, userModel.UserClearance);
        }

        #endregion
    }
}