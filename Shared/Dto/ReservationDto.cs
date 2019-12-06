using Shared.Enums;
using EnumsNET;
using System;

namespace Shared.Dto
{
    public class ReservationDto
    {
        #region Constructor(s)

        public ReservationDto()
        {
        }

        public ReservationDto(int id, DateTime startTime, DateTime endTime, RoomDto room, UserDto userModel, UserClearance requiredClearance)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            Initiator = userModel;
            RequiredClearance = requiredClearance;
        }

        #endregion

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeSpan => EndTime.Subtract(StartTime);
        public RoomDto Room { get; set; }
        public UserDto Initiator { get; set; }
        public UserClearance RequiredClearance { get; set; }

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Room)}: {Room}, {nameof(Initiator)}: {Initiator}, {nameof(RequiredClearance)}: {RequiredClearance.GetName()}";
        }
    }
}