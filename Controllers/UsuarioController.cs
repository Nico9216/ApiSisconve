using ClosedXML.Excel;
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
                using var workbook = new XLWorkbook(files.OpenReadStream());
                var ws = workbook.Worksheet(1);
                var data = ws.Cell(1,1).GetValue<string>();
                var data2 = ws.Cell(2,1).GetValue<string>();
                var data3 = ws.Cell(3,1).GetValue<string>();
                
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
