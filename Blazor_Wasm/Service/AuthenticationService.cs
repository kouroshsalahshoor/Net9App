using Blazor_Wasm.Service.IService;
using Blazor_Wasm.Utilities;
using Core.Common;
using Core.Dtos.API;
using Core.Dtos.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Blazor_Wasm.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly LocalStorage _localStorage;
        private readonly AuthenticationStateProvider _authtateProvider;

        public AuthenticationService(HttpClient httpClient, LocalStorage localStorage, AuthenticationStateProvider authtateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authtateProvider = authtateProvider;
        }

        public async Task<ResponseDto> Login(LoginDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var body = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("account/login", body);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(responseContent);

            if (result!.IsSuccessful)
            {
                await _localStorage.SetAsync(Constants.Local_Token, result.Token!);
                await _localStorage.SetAsync(Constants.Local_User, result.UserDto!);

                ((AuthStateProvider)_authtateProvider).NotifyLoggedIn(result.Token);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new ResponseDto() { IsSuccessful = true };
            }

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveAsync(Constants.Local_Token);
            await _localStorage.RemoveAsync(Constants.Local_User);

            ((AuthStateProvider)_authtateProvider).NotifyLogOut();

            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<ResponseDto> Register(RegisterDto dto)
        {
            var content = JsonConvert.SerializeObject(dto);
            var body = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("account/register", body);
            if (response.StatusCode.ToString() == "Created")
            {
                return new ResponseDto() { IsSuccessful = true };
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(responseContent);

            if (result!.IsSuccessful)
            {
                return new ResponseDto() { IsSuccessful = true };
            }

            return new ResponseDto() { IsSuccessful = false, Errors = result.Errors!.ToList() };
        }
    }
}
