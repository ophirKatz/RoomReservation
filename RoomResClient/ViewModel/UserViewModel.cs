using Shared.Dto;
using Shared.Enums;

namespace RoomResClient.ViewModel
{
    public class UserViewModel : IUserViewModel
    {
        #region Constructor

        public UserViewModel(UserDto userDto)
        {
            Name = userDto.Name;
            UserClearance = userDto.UserClearance;
            Display = true;
        }

        #endregion

        #region Implementation of IUserViewModel

        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }
        public bool Display { get; set; }

        #endregion
    }
}