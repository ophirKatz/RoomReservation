using System.Collections.Generic;

namespace Shared.Data.Auth.Response
{
    public class RegisterResult : AuthActionResult
    {
        public IEnumerable<string> Errors { get; set; }
    }
}