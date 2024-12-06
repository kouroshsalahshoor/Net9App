using Blazor_Wasm.Utilities;
using Core.Common;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Blazor_Wasm.Service
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly LocalStorage _localStorage;

        public AuthStateProvider(HttpClient httpClient, LocalStorage localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetAsync<string>(Constants.Local_Token);
            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())); //annonymous
                //return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(new[]
                //{
                //    new Claim(ClaimTypes.Name, "x@x.x")
                //}, "jwtAuthType")));
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }
    }
}
