using EnumsNET;
using Shared.Enums;
using System;

namespace Server.Model
{
    public class ReservationModel : IReservationModel
    {
        #region Constructor(s)

        public ReservationModel(int id, DateTime startTime, DateTime endTime, IRoomModel room, IUserModel initiator, UserClearance requiredClearance)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            Initiator = initiator;
            RequiredClearance = requiredClearance;
        }

        #endregion

        #region Implementation of IReservationModel

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan  => EndTime.Subtract(StartTime);
        public IRoomModel Room { get; set; }
        public IUserModel Initiator { get; set; }
        public UserClearance RequiredClearance { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Room)}: {Room.Description}, {nameof(Initiator)}: {Initiator.Name}, {nameof(RequiredClearance)}: {RequiredClearance.GetName()}";
        }
    }
}