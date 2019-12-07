using EnumsNET;
using Shared.Enums;

namespace Server.Model
{
    public class UserModel : IUserModel
    {
        #region Constructor(s)

        public UserModel(string username, UserClearance userClearance)
        {
            Name = username;
            UserClearance = userClearance;
        }

        #endregion

        #region Implementation of IUserModel

        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}