using Shared.Data.Auth.Response;
using Shared.Dto.Auth.Request;
using System.Threading.Tasks;

namespace RoomResClient.Client.Services
{
    public interface IUserAuthService
    {
        Task<LoginResult> Login(LoginData loginData);
        Task Logout();
        Task<RegisterResult> Register(RegisterData registerData);
    }
}