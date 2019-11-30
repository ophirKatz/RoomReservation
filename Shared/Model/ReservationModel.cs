using Common.Enums;
using EnumsNET;
using System;

namespace Common.Model
{
    public class ReservationModel : IReservationModel
    {
        #region Constructor

        public ReservationModel(DateTime startTime, DateTime endTime, IRoomModel room, IUserModel userModel, UserClearance requiredClearance)
        {
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            Initiator = userModel;
            RequiredClearance = requiredClearance;
        }

        #endregion

        #region Implementation of IReservationModel

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan => EndTime.Subtract(StartTime);
        public IRoomModel Room { get; set; }
        public IUserModel Initiator { get; set; }
        public UserClearance RequiredClearance { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Room)}: {Room}, {nameof(Initiator)}: {Initiator}, {nameof(RequiredClearance)}: {RequiredClearance.GetName()}";
        }
    }
}