using Common.Enums;
using EnumsNET;
using System.Collections.Generic;

namespace Common.Model
{
    public class BasicUserModel : IUserModel
    {
        #region Constructor(s)

        public BasicUserModel(string name, string id, UserClearance userClearance, List<IReservationModel> reservations)
        {
            Name = name;
            Id = id;
            UserClearance = userClearance;
            RoomReservations = reservations;
        }

        public BasicUserModel(string name, string id, UserClearance userClearance)
            : this(name, id, userClearance, new List<IReservationModel>())
        {
        }

        #endregion

        #region Implementation of IUserModel

        public string Id { get; set; }
        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }
        public List<IReservationModel> RoomReservations { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}