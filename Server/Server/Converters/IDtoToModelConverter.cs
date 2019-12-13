using Server.Model;
using Shared.Dto;

namespace Server.Server.Converters
{
    public interface IDtoToModelConverter
    {
        IReservationModel ConvertReservationDetails(ReservationDetails reservationDetails, IUserModel userModel, IRoomModel roomModel);
    }
}