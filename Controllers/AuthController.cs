using IdentityAndDataProtection.DTOs;
using IdentityAndDataProtection.Enities;
using IdentityAndDataProtection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndDataProtection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly UserManager<ApplicationUser> _userManager; IdentityUserdan miras aldığı için ApplicationUser olacak.

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FullName = registerDto.FullName
            };
          var result =  await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Başarılı Kayıt");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto) 
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized("Kullanıcı bulunamadı.");

            var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!check)
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }


    }
}
