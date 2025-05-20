using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo_API.Data;
using ToDo_API.Dtos;
using ToDo_API.Helper;
using ToDo_API.Models;

namespace ToDo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ToDoDbContext _context;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AccountsController(UserManager<ApplicationUser> userManager, ToDoDbContext context, JwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAluno([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailEmUso = await _userManager.FindByEmailAsync(loginDto.Email);
            if (emailEmUso != null)
                return BadRequest("E-mail já está em uso.");

            var user = new ApplicationUser
            {
                UserName = loginDto.Email,
                Email = loginDto.Email,
            };

            var result = await _userManager.CreateAsync(user, loginDto.Senha);

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok(new { message = "Usuário registrado com sucesso." });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Senha))
                return Unauthorized("Usuário ou senha inválidos");

            var token = await _jwtTokenGenerator.GenerateToken(user);

            Response.Cookies.Append("auth_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(2),
                Path = "/"           
            });

            return Ok(new { message = "Login realizado com sucesso." });
        }
    }
}
