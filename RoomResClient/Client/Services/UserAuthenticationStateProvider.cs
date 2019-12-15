using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace RoomResClient.Client.Services
{
    public class UserAuthenticationStateProvider : AuthenticationStateProvider
    {
        #region Constructor

        public UserAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            LocalStorageService = localStorageService;
        }

        #endregion

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await LocalStorageService.GetItemAsync<string>(Data.Consts.AuthToken)
                .ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return AuthenticationStateBuilder.Empty;
            }

            return AuthenticationStateBuilder.FromJwt(savedToken);
        }

        public void AuthenticateUser(string username)
        {
            var authState = Task.FromResult(AuthenticationStateBuilder.FromUsername(username));
            NotifyAuthenticationStateChanged(authState);
        }

        public void LogoutUser()
        {
            var authState = Task.FromResult(AuthenticationStateBuilder.Empty);
            NotifyAuthenticationStateChanged(authState);
        }

        #region Private Members

        private ILocalStorageService LocalStorageService { get; }

        #endregion
    }
}