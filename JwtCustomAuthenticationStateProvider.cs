using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorBooksStore
{
    public class JwtCustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _storage;
        public JwtCustomAuthenticationStateProvider(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(await _storage.ContainKeyAsync("access_token"))
            {
                //Read and parse the token
                var tokenAsString = await _storage.GetItemAsync<string>("access_token");
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(tokenAsString);
                var identity = new ClaimsIdentity(token.Claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                var authState = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(authState));

                return authState;

            }
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity()); // No claims or authentication scheme provided
            // authentication scheme provided
            var anonymousState = new AuthenticationState(anonymousUser);
            NotifyAuthenticationStateChanged(Task.FromResult(anonymousState));
            return anonymousState;
        }

    }
    
}
