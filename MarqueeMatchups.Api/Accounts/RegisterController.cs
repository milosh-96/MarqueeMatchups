using MarqueeMatchups.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarqueeMatchups.Api.Accounts
{
        [ApiController]
        [Route("/accounts/[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public RegisterController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        [ProducesErrorResponseType(typeof(ApplicationUser))]
        public async Task<IActionResult> Get([FromBody]RegisterDto data)
        {
            var user = new ApplicationUser()
            {
                UserName = data.UserName,
                Email = data.Email
            };
            string passwordHash = _passwordHasher.HashPassword(user, data.Password);
            user.PasswordHash = passwordHash;
            var result =  await _userManager.CreateAsync(user);
            return new JsonResult(result);
        }
    }
}
