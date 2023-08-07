using MarqueeMatchups.Api.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace MarqueeMatchups.Api.Accounts
{
    [Route("api/accounts/[controller]/{action=Login}")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto data)
        {
          

            ApplicationUser user = await _userManager.FindByEmailAsync(data.Email);

            if(user != null) {
                var result = await _signInManager.PasswordSignInAsync(user, data.Password, data.RememberMe, false);

                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, true);
                   
                    //return new JsonResult(CreateToken(user));
                }
            }
            return new JsonResult(_signInManager.IsSignedIn(User));
            return new StatusCodeResult(401);
        }

        private string CreateToken(ApplicationUser user)
        {
            List<Claim> userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            string? tokenKey = _configuration.GetSection("AppSettings:SecretKey").Value;
           if(tokenKey == null) { throw new Exception("missing secret key in appsettings for jwt"); }
            {
                var key = new SymmetricSecurityKey(
                   System.Text.Encoding.UTF8.GetBytes(tokenKey)
                  );

                var userCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: userClaims,
                    issuer: "MarqueeMatchups",
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: userCredentials
                   );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
           
        }

        [HttpGet]
        public IActionResult LoginCheck()
        {
            return new JsonResult(new { loggedIn = _signInManager.IsSignedIn(User) });
        }
    }
}
