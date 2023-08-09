using MarqueeMatchups.Api.Data.Identity;
using MarqueeMatchups.Api.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeMatchups.Api.Accounts
{
    [Route("api/accounts/[controller]/{action=Login}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtTokenGeneratorService _jwtTokenGenerator;
        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration, JwtTokenGeneratorService jwtTokenGenerator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto data)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(data.Email);
            if (user != null)
            {
                await _signInManager.PasswordSignInAsync(user, data.Password, true, false);
                var signedIn = _signInManager.IsSignedIn(User);
                if (signedIn)
                {
                    return new JsonResult(_jwtTokenGenerator.CreateToken(user));
                }
                return new JsonResult("isn't signed in!");
            }
            return new JsonResult("login failed");
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult IsLoggedIn()
        {
            return new OkResult();
        } 
    }


}

