using Shared.Enums;

namespace Server.Model
{
    public interface IUserModel
    {
        string Name { get; set; }
        UserClearance UserClearance { get; set; }

        delegate IUserModel Factory(string username,
            UserClearance userClearance);
    }
}