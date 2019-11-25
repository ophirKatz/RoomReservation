using Common.Enums;
using EnumsNET;

namespace Common.Model
{
    public class BasicUserModel : IUserModel
    {
        #region Constructor(s)

        public BasicUserModel(string name, string id, UserClearance userClearance)
        {
            Name = name;
            Id = id;
            UserClearance = userClearance;
        }

        #endregion

        public string Id { get; set; }
        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}