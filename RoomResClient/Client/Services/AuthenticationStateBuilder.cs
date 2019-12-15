using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using RoomResClient.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RoomResClient.Client.Services
{
    public static class AuthenticationStateBuilder
    {
        public static AuthenticationState Empty => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public static AuthenticationState FromUsername(string username) => new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, AuthenticationType)));

        public static AuthenticationState FromJwt(string jwt)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(jwt),
                JwtAuthenticationType)));

            static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
            {
                var claims = new List<Claim>();
                var payload = jwt.Split('.')[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var keyValuePairs = JsonSerializer.Create().Deserialize<Dictionary<string, object>>(jsonBytes);

                keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

                if (roles != null)
                {
                    if (roles.ToString().Trim().StartsWith("["))
                    {
                        var parsedRoles = JsonSerializer.Create().Deserialize<string[]>(roles.ToString());

                        foreach (var parsedRole in parsedRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                        }
                    }
                    else
                    {
                        claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                    }

                    keyValuePairs.Remove(ClaimTypes.Role);
                }

                claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

                return claims;
            }

            static byte[] ParseBase64WithoutPadding(string base64)
            {
                switch (base64.Length % 4)
                {
                    case 2: base64 += "=="; break;
                    case 3: base64 += "="; break;
                }

                return Convert.FromBase64String(base64);
            }
        }

        private const string AuthenticationType = "apiauth"; // TODO : check this, whats the meaning
        private const string JwtAuthenticationType = "jwt"; // TODO : check this, whats the meaning
    }
}