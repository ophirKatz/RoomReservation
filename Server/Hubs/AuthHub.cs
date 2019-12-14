using Microsoft.AspNetCore.SignalR;
using Shared.Communication;
using Shared.Data.Auth.Response;
using Shared.Dto.Auth.Request;

namespace Server.Hubs
{
    public class AuthHub : Hub, IAuthHub
    {
        // TODO
        #region Implementation of IAuthHub

        public LoginResult Login(LoginData loginData)
        {
            return new LoginResult
            {
                Result = Shared.Enums.AuthResult.Success,
                Token = "token"
            };
        }

        public RegisterResult Register(RegisterData registerData)
        {
            return new RegisterResult
            {
                Result = Shared.Enums.AuthResult.Success
            };
        }

        #endregion
    }
}