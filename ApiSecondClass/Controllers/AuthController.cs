using Bussines.ApiSecond.Interfaces;
using Domain.ApiSecond;
using Domain.ApiSecond.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiSecondClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioBussines _usuarioBussines;

        public AuthController(IConfiguration configuration, IUsuarioBussines usuarioBussines)
        {
            _configuration = configuration;
            _usuarioBussines = usuarioBussines;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto login)
        {
            var keyconfig = _configuration["Jwt:Key"];
            var usuario = _usuarioBussines.GetUsuario(login.Usuario, login.Password);

            if (usuario == null 
                || string.IsNullOrEmpty(usuario.Email)
                || login.Key != keyconfig)
            {
                return Unauthorized();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, login.Usuario),
                    new Claim( "Email", usuario.Email),
                    new Claim( "Rol", usuario.Idrol.ToString())
                },
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: credentials);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiracion = token.ValidTo
            });
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public ActionResult CreateUser(UsuarioDto usuario)
        {
            return Ok(_usuarioBussines.CreateUser(usuario));
        }
    }
}
