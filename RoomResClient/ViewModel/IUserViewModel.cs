using Shared.Enums;

namespace RoomResClient.ViewModel
{
    public interface IUserViewModel
    {
        bool Display { get; set; }
        string Name { get; set; }
        UserClearance UserClearance { get; set; }
    }
}