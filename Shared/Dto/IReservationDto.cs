using Common.Enums;
using System;

namespace Common.Dto
{
    public interface IReservationDto
    {
        int Id { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan TimeSpan { get; }
        IRoomDto Room { get; set; }
        IUserDto Initiator { get; set; }
        UserClearance RequiredClearance { get; set; }
    }
}