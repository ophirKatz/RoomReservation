using Common.Enums;
using System.Collections.Generic;

namespace Common.Dto
{
    public interface IUserDto
    {
        string Name { get; set; }
        UserClearance UserClearance { get; set; }
        List<IReservationDto> RoomReservations { get; set; }
    }
}