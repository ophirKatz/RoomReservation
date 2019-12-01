using Common.Enums;
using EnumsNET;
using System;

namespace Common.Dto
{
    public class ReservationDto : IReservationDto
    {
        #region Constructor

        public ReservationDto(int id, DateTime startTime, DateTime endTime, IRoomDto room, IUserDto userModel, UserClearance requiredClearance)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            Initiator = userModel;
            RequiredClearance = requiredClearance;
        }

        #endregion

        #region Implementation of IReservationModel

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan => EndTime.Subtract(StartTime);
        public IRoomDto Room { get; set; }
        public IUserDto Initiator { get; set; }
        public UserClearance RequiredClearance { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Room)}: {Room}, {nameof(Initiator)}: {Initiator}, {nameof(RequiredClearance)}: {RequiredClearance.GetName()}";
        }
    }
}