namespace Shared.Data.Auth.Response
{
    public class LoginResult : AuthActionResult
    {
        public string Error { get; set; }
        public string Token { get; set; }
    }
}