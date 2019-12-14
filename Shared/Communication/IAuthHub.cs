using Shared.Data.Auth.Response;
using Shared.Dto.Auth.Request;

namespace Shared.Communication
{
    public interface IAuthHub
    {
        LoginResult Login(LoginData loginData);
        RegisterResult Register(RegisterData registerData);
    }
}