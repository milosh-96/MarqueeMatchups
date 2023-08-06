using MarqueeMatchups.Api.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MarqueeMatchups.Api.Accounts
{
    [Route("api/accounts/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto data)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return new JsonResult("you are already signed in");
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(data.Email);

            if(user != null) {
                var result = await _signInManager.PasswordSignInAsync(user, data.Password, data.RememberMe, false);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);
                   
                    return new JsonResult(User);
                }
            }
            return new JsonResult(new { message = "login failed!" });
        }
    }
}
