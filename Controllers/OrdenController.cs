using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sisconve.Models;
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
    public class OrdenController : Controller
    {
        private readonly IConfiguration config;
        private readonly IPersistenciaOrden per;
        public OrdenController(IConfiguration _config, PersistenciaOrden _per)
        {
            this.per = _per;
            config = _config;
        }

        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = 100_000_000, MultipartBodyLengthLimit = 100_000_000)]
        public async Task<IActionResult> Post([FromForm] IFormFile files)
        {
            try
            {
                var workbook = new XLWorkbook(files.OpenReadStream());
                var ws = workbook.Worksheet(1);
                int row = 2;
                bool finished = false;
                List<Orden> ordenes = new List<Orden>();

                while (finished == false)
                {
                    string orden = ws.Cell(row, 1).GetValue<string>();
                    string fechaIngreso = ws.Cell(row, 2).GetValue<string>();
                    string usuarioIngreso = ws.Cell(row, 3).GetValue<string>();
                    string fechaCordInicio = ws.Cell(row, 4).GetValue<string>();
                    string fechaCordFin = ws.Cell(row, 5).GetValue<string>();
                    string fechaFinalización = ws.Cell(row, 6).GetValue<string>();
                    string movil = ws.Cell(row, 7).GetValue<string>();
                    string lugar = ws.Cell(row, 8).GetValue<string>();
                    string estado = ws.Cell(row, 9).GetValue<string>();
                    string comentarios = ws.Cell(row, 10).GetValue<string>();
                    if (orden != "")
                    {
                        Orden ordenObj = new Orden();
                        ordenObj.OrdenNumero = Convert.ToInt64(orden);
                        ordenObj.OrdenFechaIngreso = Convert.ToDateTime(fechaIngreso);
                        ordenObj.OrdenUsuarioNombre = usuarioIngreso;
                        ordenObj.OrdenFechaInicioCoordinacion = Convert.ToDateTime(fechaCordInicio);
                        ordenObj.OrdenFechaFinCoordinacion = Convert.ToDateTime(fechaCordFin);
                        if (fechaFinalización != "")
                        {
                            ordenObj.OrdenFechaFinalizacion = Convert.ToDateTime(fechaFinalización);
                        }
                        ordenObj.OrdenMovil = movil;
                        ordenObj.OrdenLugar = lugar;
                        ordenObj.OrdenEstado = estado;
                        ordenObj.OrdenComentario = comentarios;

                        ordenes.Add(ordenObj);
                        row++;
                    }
                    else { finished = true; }
                }

                string resp = await per.AgregarOrdenes(ordenes);


                return Ok();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string tipo, string fechaDesde, string fechaHasta)
        {
            try {
                List<ResponseOrden> ordenes = await per.ListarOrdenes(tipo, fechaDesde, fechaHasta);
                return Ok(ordenes);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
