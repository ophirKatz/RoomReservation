using Shared.Enums;
using System;

namespace RoomResClient.Data.EventArgs
{
    public class MakeReservationEventArgs : System.EventArgs
    {
        public MakeReservationEventArgs(DateTime? startTime, DateTime? endTime, UserClearance requiredClearance)
        {
            StartTime = startTime ?? DateTime.Now;
            EndTime = endTime ?? DateTime.Now;
            RequiredClearance = requiredClearance;
        }

        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public UserClearance RequiredClearance { get; }
    }
}