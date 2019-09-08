using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EquixAPI.Entities;
using EquixAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EquixAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly EquixAPIContext _context;
        private readonly IMapper _mapper;

        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            EquixAPIContext context, 
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            this._context = context;
            this._mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var author = _mapper.Map<Author>(model.Author);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AuthorId = author.Id, Author = author };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { ok = true, data = BuildToken(model, author) });
            }
            else
            {
                return BadRequest(new { ok = false, errors = result.Errors });
            }

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            var user = _context.Users.Include(x => x.Author).SingleOrDefault(x => x.Email == userInfo.Email );
            //var author = await _context.Authors.FindAsync(user.AuthorId);
            if (result.Succeeded)
            {
                return Ok(new { ok = true, data = BuildToken(userInfo, user.Author) });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                var errors = ModelState.SelectMany(x => x.Value.Errors)
                            .Select(e => e.ErrorMessage).ToList();

                return BadRequest(new { ok = false, errors });
            }
        }

        private UserToken BuildToken(UserInfo userInfo, Author author)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Author = _mapper.Map<OutAuthorDTO>(author)
            };
        }
    }
}