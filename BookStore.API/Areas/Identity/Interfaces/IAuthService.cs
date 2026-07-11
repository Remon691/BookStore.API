using BookStore.API.Areas.Identity.Dtos.Requests;
using BookStore.API.Areas.Identity.Dtos.Responses;
namespace BookStore.API.Areas.Identity.Interfaces
{
    public interface IAuthService
    {
         Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto);
         Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
       
    }
}
