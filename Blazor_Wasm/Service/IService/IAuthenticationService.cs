using Core.Dtos.API;
using Core.Dtos.Auth;

namespace Blazor_Wasm.Service.IService
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> Register(RegisterDto dto);
        Task<ResponseDto> Login(LoginDto dto);
        Task Logout();
    }
}
