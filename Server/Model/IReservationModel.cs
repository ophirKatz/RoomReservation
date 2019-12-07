using Shared.Enums;
using System;

namespace Server.Model
{
    public interface IReservationModel
    {
        int Id { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        TimeSpan TimeSpan { get; }
        IRoomModel Room { get; set; }
        IUserModel Initiator { get; set; }
        UserClearance RequiredClearance { get; set; }

        delegate IReservationModel Factory(int id,
            DateTime startTime,
            DateTime endTime,
            IRoomModel room,
            IUserModel initiator,
            UserClearance requiredClearance);
    }
}