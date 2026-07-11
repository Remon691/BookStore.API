
using BookStore.API.Areas.Identity.Dtos.Requests;
using BookStore.API.Areas.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Areas.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _iauthService;
        public AuthController(IAuthService iauthService)
        {
            _iauthService = iauthService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            var resultRegister = await _iauthService.RegisterAsync(registerRequestDto);
            if (resultRegister.IsSuccess == false)
            {
                return BadRequest(resultRegister);
            }

            return Ok(resultRegister);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
           var result= await _iauthService.LoginAsync(loginRequestDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
