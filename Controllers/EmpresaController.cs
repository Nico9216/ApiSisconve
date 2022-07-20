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

        [HttpGet("GetById/{empresaId}")]
        public async Task<IActionResult> Get( int empresaId)
        {
            try
            {
                ResponseEmpresa empresa= await per.BuscarEmpresa(empresaId);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(ResponseEmpresa empresa)
        {
            try
            {

                await per.AgregarEmpresa(empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ResponseEmpresa empresa)
        {
            try
            {

                await per.ModificarEmpresa(empresa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}
