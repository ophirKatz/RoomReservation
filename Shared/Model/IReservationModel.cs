using Common.Enums;
using System;

namespace Common.Model
{
    public interface IReservationModel
    {
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan TimeSpan { get; }
        IRoomModel Room { get; set; }
        IUserModel Initiator { get; set; }
        UserClearance RequiredClearance { get; set; }
    }
}