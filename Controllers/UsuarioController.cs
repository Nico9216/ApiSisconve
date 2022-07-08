using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Sisconve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IConfiguration config;
        public UsuarioController(IConfiguration _config)
        {
            config = _config;
        }
        
        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = 100_000_000, MultipartBodyLengthLimit = 100_000_000)]
        public  IActionResult Post([FromForm] IFormFile files)
        {
            try
            {
                string test = "testing";

                return Ok("Funciono");

               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
