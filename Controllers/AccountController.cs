using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using ClinicaVeterinaraAPI.Models;
using ClinicaVeterinaraAPI.Data; 

namespace ClinicaVeterinaraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClinicaVeterinaraP1Context _context; 

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager,
                                 ClinicaVeterinaraP1Context context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context; 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return Unauthorized(new LoginResult { IsSuccess = false, Message = "Utilizator inexistent." });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault() ?? "Proprietar";

             
                var proprietarDb = await _context.Proprietar
                    .FirstOrDefaultAsync(p => p.Email == request.Email);

                int realId = proprietarDb?.ProprietarId ?? 0;

                return Ok(new LoginResult
                {
                    IsSuccess = true,
                    Email = user.Email,
                    UserRole = role,
                    BusinessId = realId, 
                    Message = "Succes"
                });
            }

            return Unauthorized(new LoginResult { IsSuccess = false, Message = "Parolă greșită." });
        }
    }
}