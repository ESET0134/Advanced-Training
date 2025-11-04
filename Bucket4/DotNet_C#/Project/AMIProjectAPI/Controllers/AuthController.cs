using AMIProjectAPI.Models;
using AMIProjectAPI.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AMIProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AmiprojectContext _context;
        private readonly ITokenService _tokenService;

        public AuthController(AmiprojectContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // 🔹 LOGIN FOR USERS
        [HttpPost("login-user")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest req)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == req.Username);
            if (user == null)
                return Unauthorized("Invalid username or password");

            // 🔸 Check active status
            if (!user.Status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                return Forbid("User is inactive");

            bool passwordValid;
            try
            {
                passwordValid = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
            }
            catch
            {
                passwordValid = req.Password == user.Password;
            }

            if (!passwordValid)
                return Unauthorized("Invalid username or password");

            // 🔸 Upgrade plaintext password to hash
            if (!user.Password.StartsWith("$2"))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            var claims = new List<Claim>
            {
                new Claim("UserType", "User"),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.UserId.ToString())
            };

            var token = _tokenService.CreateToken(claims);
            return Ok(new { Token = token });
        }

        // 🔹 LOGIN FOR CONSUMERS
        [HttpPost("login-consumer")]
        public async Task<IActionResult> LoginConsumer([FromBody] LoginRequest req)
        {
            var cl = await _context.ConsumerLogins
                .FirstOrDefaultAsync(x => x.Username == req.Username);

            if (cl == null)
                return Unauthorized("Invalid username or password");

            // 🔸 Check status
            if (!cl.Status.Equals("Active", StringComparison.OrdinalIgnoreCase))
                return Forbid("Consumer is inactive");

            // 🔸 Check verification
            if (cl.IsVerified == false)
                return Forbid("Consumer not verified");

            bool passwordValid;
            try
            {
                passwordValid = BCrypt.Net.BCrypt.Verify(req.Password, cl.Password);
            }
            catch
            {
                passwordValid = req.Password == cl.Password;
            }

            if (!passwordValid)
                return Unauthorized("Invalid username or password");

            // 🔸 Upgrade plaintext to bcrypt if needed
            if (!cl.Password.StartsWith("$2"))
            {
                cl.Password = BCrypt.Net.BCrypt.HashPassword(req.Password);
                _context.ConsumerLogins.Update(cl);
                await _context.SaveChangesAsync();
            }

            var claims = new List<Claim>
            {
                new Claim("UserType", "Consumer"),
                new Claim(ClaimTypes.Name, cl.Username),
                new Claim("ConsumerId", cl.ConsumerId.ToString())
            };

            var token = _tokenService.CreateToken(claims);
            return Ok(new { Token = token });
        }
    }

    // 🔸 Simple DTO for login request
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
