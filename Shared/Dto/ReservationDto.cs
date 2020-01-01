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

        public ReservationDto(int id, DateTime startTime, DateTime endTime, RoomDto room, UserDto userDto, UserClearance requiredClearance)
        {
            Id = id;
            Details = new ReservationDetails
            {
                StartTime = startTime,
                EndTime = endTime,
                RequiredClearance = requiredClearance
            };
            Room = room;
            Initiator = userDto;
        }

        #endregion

        public int Id { get; set; }
        public ReservationDetails Details { get; set; }
        public TimeSpan TimeSpan => Details.EndTime.Subtract(Details.StartTime);
        public RoomDto Room { get; set; }
        public UserDto Initiator { get; set; }

        public override string ToString()
        {
            return $"{nameof(Details)}: {Details}, {nameof(Room)}: {Room}, {nameof(Initiator)}: {Initiator}";
        }
    }
}