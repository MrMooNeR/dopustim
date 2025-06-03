using dopustim.Helpers;
using Microsoft.AspNetCore.Mvc;
using dopustim.Data;
using dopustim.Models;
using System.Linq;
using System.Threading.Tasks;

namespace dopustim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LibraryContext _db;
        private readonly IConfiguration _config;

        public AuthController(LibraryContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (_db.Users.Any(u => u.Username == dto.Username))
                return BadRequest("User exists");

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _db.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized();

            var token = JwtHelper.GenerateToken(user.Id, user.Username, _config);
            return Ok(new { token, userId = user.Id });

        }
    }

    public record RegisterDto(string Username, string Password);
    public record LoginDto(string Username, string Password);
}