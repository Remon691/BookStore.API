using BookStore.API.Areas.Identity.Dtos.Requests;
using BookStore.API.Areas.Identity.Dtos.Responses;
using BookStore.API.Areas.Identity.Interfaces;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Areas.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto registerRequestDto)
        // هنا انا مش هتحقق بنفسى من اليوزر نيم والايميل لان الكريت ميثود هى بتعمل ده بالفعل لحظه الكريت
        {
            //var resultEmail = await _userManager.FindByEmailAsync(email: registerRequestDto.Email);
            //if (resultEmail != null)
            //{
            //    return new AuthResponseDto
            //    {
            //        IsSuccess = false,
            //        Message = "Email used."
            //    };
            //}
            //var resultUserName = await _userManager.FindByNameAsync(userName: registerRequestDto.UserName);
            //if (resultUserName != null)
            //{
            //    return new AuthResponseDto
            //    {
            //        IsSuccess = false,
            //        Message = "UserName used."
            //    };
            //}
            ApplicationUser user = new()
            {
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName,
                UserName = registerRequestDto.UserName,
                Address = registerRequestDto.Address,
                Email = registerRequestDto.Email,
            };
            var createResult = await _userManager.CreateAsync(user, registerRequestDto.Password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = errors
                };
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Patient");
            if (!roleResult.Succeeded)
            {
                var errors = string.Join(",", roleResult.Errors.Select(e => e.Description));
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = errors
                };
            }
            return new AuthResponseDto
            {
                IsSuccess = true,
                Message = " Registration completed successfully."
            };

        }
        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var resultEmailOrUserName = await _userManager.FindByEmailAsync(email: loginRequestDto.EmailOrUserName) ??
                await _userManager.FindByNameAsync(userName: loginRequestDto.EmailOrUserName);
            if (resultEmailOrUserName == null)
            {
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = " Invalid username/email or password."
                };
            }
            var resultPass = await _signInManager.CheckPasswordSignInAsync(resultEmailOrUserName, password: loginRequestDto.Password, false);
            if (!resultPass.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = " Password incorrect."
                };
            }
            var token = await _tokenService.GenerateTokenAsync(resultEmailOrUserName);

            return new AuthResponseDto
            {
                IsSuccess = true,
                Message = " Login completed successfully.",
                Token = token

            };
        }

    }
}
