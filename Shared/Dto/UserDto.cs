using Common.Enums;
using EnumsNET;

namespace Common.Dto
{
    public class UserDto
    {
        #region Constructor(s)

        public UserDto()
        {

        }

        public UserDto(string name, UserClearance userClearance)
        {
            Name = name;
            UserClearance = userClearance;
        }

        #endregion

        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(UserClearance)}: {UserClearance.GetName()}";
        }
    }
}