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
using System.IO;
using System.Threading;
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
        [HttpPost("{ordenes}")]

        public IActionResult Get(List<ResponseOrden> ordenes)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ordenes");
                    var currentRow = 1;

                    #region Header
                    worksheet.Cell(currentRow, 1).Value = "Número";
                    worksheet.Cell(currentRow, 2).Value = "Fecha Ingreso";
                    worksheet.Cell(currentRow, 3).Value = "Usuario";
                    worksheet.Cell(currentRow, 4).Value = "Fec. Ini Coord";
                    worksheet.Cell(currentRow, 5).Value = "Fec. Fin Coord";
                    worksheet.Cell(currentRow, 6).Value = "Fecha Finalización";
                    worksheet.Cell(currentRow, 7).Value = "Móvil";
                    worksheet.Cell(currentRow, 8).Value = "Lugar";
                    worksheet.Cell(currentRow, 9).Value = "Comentario";
                    worksheet.Cell(currentRow, 10).Value = "Empresa";
                    worksheet.Cell(currentRow, 11).Value = "Funcionario";
                    #endregion

                    #region Body
                    ordenes.ForEach(o =>
                    {
                        currentRow++;
                        worksheet.Cell(currentRow, 1).Value = o.ordenNumero.ToString();
                        worksheet.Cell(currentRow, 2).Value = o.ordenFechaIngreso?.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cell(currentRow, 3).Value = o.ordenUsuarioNombre;
                        worksheet.Cell(currentRow, 4).Value = o.ordenFechaInicioCoordinacion?.ToString("dd/MM/yyyy");
                        worksheet.Cell(currentRow, 5).Value = o.ordenFechaFinCoordinacion?.ToString("dd/MM/yyyy");
                        worksheet.Cell(currentRow, 6).Value = o.ordenFechaFinalizacion?.ToString("dd/MM/yyyy HH:mm");
                        worksheet.Cell(currentRow, 7).Value = o.ordenMovil;
                        worksheet.Cell(currentRow, 8).Value = o.ordenLugar;
                        worksheet.Cell(currentRow, 9).Value = o.ordenComentario;
                        worksheet.Cell(currentRow, 10).Value = o.ordenEmpresaNombre;
                        worksheet.Cell(currentRow, 11).Value = o.ordenFuncionarioNombre + " " + o.ordenFuncionarioApellido;
                        if (currentRow % 2 == 1)
                        {
                            IXLRange range = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 11).Address); //Las celdas del Header
                            range.Style.Fill.SetBackgroundColor(XLColor.LightBlue);
                        }

                    });
                    #endregion

                    // Selecciono un rango de celdas al cual aplicar estilos
                    IXLRange range = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, 25).Address); //Las celdas del Header

                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Medium; //Borde
                    range.Style.Font.SetBold(true); //Bold
                    range.Style.Font.SetFontColor(XLColor.White);
                    range.Style.Fill.SetBackgroundColor(XLColor.Red); //Backgroundcolor
                    worksheet.RangeUsed().SetAutoFilter(); //Aplica filtro a cada columna
                    worksheet.Columns().AdjustToContents();
                    worksheet.Columns().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();

                        String file = Convert.ToBase64String(content);
                        return Ok(file);
                    }

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
