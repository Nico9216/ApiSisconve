using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sisconve.Models.Response;
using Sisconve.Persistencia;
using Sisconve.Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sisconve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IConfiguration config;
        private readonly IPersistenciaEmpresa per;
        public EmpresaController(IConfiguration _config, PersistenciaEmpresa _per)
        {
            this.per = _per;
            config = _config;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                List<ResponseEmpresa> empresas = await per.ListarEmpresas();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
