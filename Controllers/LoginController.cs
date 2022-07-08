using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sisconve.Models;
using Sisconve.Persistencia;
using Sisconve.Persistencia.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sisconve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IPersistenciaUsuario per;
        private readonly IConfiguration config;

        public LoginController(IConfiguration _config, PersistenciaUsuario _per)
        {
            config = _config;
            this.per = _per;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string ci, [FromQuery] string pass)
        {
            try
            {
                
                Usuario usuario = await per.Login(ci, pass);

                if (usuario != null)
                {
                    var secretKey = config.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioCi.ToString()));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(8),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    string bearer_token = tokenHandler.WriteToken(createdToken);
                    return Ok(bearer_token);
                }
                else
                {
                    return BadRequest("Cédula y/o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
