using Common.Enums;

namespace Common.Model
{
    public interface IUserModel
    {
        string Id { get; set; }
        string Name { get; set; }
        UserClearance UserClearance { get; set; }
    }
}