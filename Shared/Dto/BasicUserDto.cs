using Common.Enums;
using EnumsNET;
using System.Collections.Generic;

namespace Common.Dto
{
    public class BasicUserDto : IUserDto
    {
        #region Constructor(s)

        public BasicUserDto(string name, UserClearance userClearance, List<IReservationDto> reservations)
        {
            Name = name;
            UserClearance = userClearance;
            RoomReservations = reservations;
        }

        public BasicUserDto(string name, UserClearance userClearance)
            : this(name, userClearance, new List<IReservationDto>())
        {
        }

        #endregion

        #region Implementation of IUserModel

        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }
        public List<IReservationDto> RoomReservations { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}