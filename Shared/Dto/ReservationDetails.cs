using EnumsNET;
using Shared.Enums;
using System;

namespace Shared.Dto
{
    public class ReservationDetails
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UserClearance RequiredClearance { get; set; }

        public override string ToString()
        {
            return $"{nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(RequiredClearance)}: {RequiredClearance.GetName()}";
        }
    }
}