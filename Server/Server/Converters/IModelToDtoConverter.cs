using Server.Model;
using Shared.Dto;

namespace Server.Server.Converters
{
    public interface IModelToDtoConverter
    {
        RoomDto ConvertRoomModelToDto(IRoomModel roomModel);
        UserDto ConvertUserModelToDto(IUserModel userModel);
        ReservationDto ConvertReservationModelToDto(IReservationModel reservationModel);
    }
}