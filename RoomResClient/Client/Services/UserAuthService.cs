using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
using Serilog;
using Shared.Communication;
using Shared.Data.Auth.Response;
using Shared.Dto.Auth.Request;
using System;
using System.Threading.Tasks;

namespace RoomResClient.Client.Services
{
    public class UserAuthService : IUserAuthService
    {
        #region Constructor

        public UserAuthService(HubConnection connection,
            ILogger logger,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorageService)
        {
            Connection = connection;
            Logger = logger;
            AuthenticationStateProvider = authenticationStateProvider;
            LocalStorageService = localStorageService;
        }

        #endregion

        #region Implementation of IAuthService
        // Add local storage RememberMe option

        public async Task<RegisterResult> Register(RegisterData registerData)
        {
            try
            {
                return await Connection.InvokeAsync<RegisterResult>(nameof(IAuthHub.Register), registerData)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Error with executing auth method {nameof(IAuthHub.Register)}");
            }

            return null;
        }

        public async Task<LoginResult> Login(LoginData loginData)
        {
            try
            {
                var result = await Connection.InvokeAsync<LoginResult>(nameof(IAuthHub.Login), loginData)
                    .ConfigureAwait(false);

                if (result.Result != Shared.Enums.AuthResult.Success)
                {
                    return result;
                }

                ((UserAuthenticationStateProvider)AuthenticationStateProvider).AuthenticateUser(loginData.Username);
                await LocalStorageService.SetItemAsync(Data.Consts.AuthToken, result.Token);

                return result;
            }
            catch (Exception e)
            {
                await Logout();
                Logger.Error(e, $"Error with executing auth method {nameof(IAuthHub.Login)}");
            }

            return null;
        }

        public async Task Logout()
        {
            await LocalStorageService.RemoveItemAsync(Data.Consts.AuthToken);
            ((UserAuthenticationStateProvider)AuthenticationStateProvider).LogoutUser();
        }

        #endregion

        #region Private Members

        private HubConnection Connection { get; }
        private ILogger Logger { get; }
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public ILocalStorageService LocalStorageService { get; }

        #endregion
    }
}