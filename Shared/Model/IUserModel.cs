using Common.Enums;
using System.Collections.Generic;

namespace Common.Model
{
    public interface IUserModel
    {
        string Id { get; set; }
        string Name { get; set; }
        UserClearance UserClearance { get; set; }
        List<IReservationModel> RoomReservations { get; set; }
    }
}