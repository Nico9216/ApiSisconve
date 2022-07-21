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

                    string ordenNumero = ws.Cell(row, 1).GetValue<string>();
                    string ordenNombreOrganizacion = ws.Cell(row, 2).GetValue<string>();
                    string ordenMovil = ws.Cell(row, 3).GetValue<string>();
                    string ordenMatricula = ws.Cell(row, 4).GetValue<string>();
                    string ordenEstado = ws.Cell(row, 5).GetValue<string>();
                    string ordenFechaInicioCoordinacion = ws.Cell(row, 6).GetValue<string>();
                    string ordenFechaFinCoordinacion = ws.Cell(row, 7).GetValue<string>();
                    string ordenFechaFinalizacion = ws.Cell(row, 8).GetValue<string>();
                    string ordenUsuarioNombreFinalizo = ws.Cell(row, 9).GetValue<string>();
                    string ordenTmpoTrabajoEnMdeo = ws.Cell(row, 10).GetValue<string>();
                    string ordenTmpoTrabajoEnInterior = ws.Cell(row, 11).GetValue<string>();
                    string ordenFechaPrimeraCarga = ws.Cell(row, 12).GetValue<string>();
                    string ordenSerieDpl = ws.Cell(row, 13).GetValue<string>();
                    string ordenDeviceIdDpl = ws.Cell(row, 14).GetValue<string>();
                    string ordenSerieDataPass = ws.Cell(row, 15).GetValue<string>();
                    string ordenMacdataPass = ws.Cell(row, 16).GetValue<string>();
                    string ordenSerieTagreader = ws.Cell(row, 17).GetValue<string>();
                    string ordenNroTagreader = ws.Cell(row, 18).GetValue<string>();
                    string ordenChip = ws.Cell(row, 19).GetValue<string>();
                    string ordenDivision = ws.Cell(row, 20).GetValue<string>();
                    string ordenFlota = ws.Cell(row, 21).GetValue<string>();
                    string ordenCardId = ws.Cell(row, 22).GetValue<string>();
                    string ordenBobina = ws.Cell(row, 23).GetValue<string>();
                    string ordenComentarioInicial = ws.Cell(row, 24).GetValue<string>();
                    string ordenTrazaOrden = ws.Cell(row, 25).GetValue<string>();
                    string ordenInstalaDpl = ws.Cell(row, 26).GetValue<string>();
                    string ordenInstalaDataPass = ws.Cell(row, 27).GetValue<string>();
                    string ordenInstalaTagreader = ws.Cell(row, 28).GetValue<string>();
                    string ordenInstalaInmovilizador = ws.Cell(row, 29).GetValue<string>();
                    string ordenLugar = ws.Cell(row, 30).GetValue<string>();
                    string ordenZonaGira = ws.Cell(row, 31).GetValue<string>();
                    string ordenNroParte = ws.Cell(row, 32).GetValue<string>();
                    string ordenCapacidadTanqueMim = ws.Cell(row, 33).GetValue<string>();
                    string ordenCapacidadTanqueMimtec = ws.Cell(row, 34).GetValue<string>();
                    string ordenInstalaCa = ws.Cell(row, 35).GetValue<string>();
                    string ordenPudoInstalarCs = ws.Cell(row, 36).GetValue<string>();
                    string ordenInstalaMebiclick = ws.Cell(row, 37).GetValue<string>();
                    string ordenEncendidoPorMotor = ws.Cell(row, 38).GetValue<string>();
    



                    if (ordenNumero != "")
                    {
                        Orden ordenObj = new Orden();
                        ordenObj.OrdenNumero=Convert.ToInt64(ordenNumero);
                        ordenObj.OrdenNombreOrganizacion =ordenNombreOrganizacion;
                        ordenObj.OrdenMovil =ordenMovil;
                        ordenObj.OrdenMatricula =ordenMatricula;
                        ordenObj.OrdenEstado=ordenEstado;
                        ordenObj.OrdenFechaInicioCoordinacion=Convert.ToDateTime(ordenFechaInicioCoordinacion);
                        ordenObj.OrdenFechaFinCoordinacion = Convert.ToDateTime(ordenFechaFinCoordinacion);
                        ordenObj.OrdenFechaFinalizacion = Convert.ToDateTime(ordenFechaFinalizacion);
                        ordenObj.OrdenUsuarioNombreFinalizo =ordenUsuarioNombreFinalizo;
                        ordenObj.OrdenTmpoTrabajoEnMdeo =ordenTmpoTrabajoEnMdeo;
                        ordenObj.OrdenTmpoTrabajoEnInterior =ordenTmpoTrabajoEnInterior;
                        ordenObj.OrdenFechaPrimeraCarga = Convert.ToDateTime(ordenFechaPrimeraCarga);
                        ordenObj.OrdenSerieDpl =ordenSerieDpl;
                        ordenObj.OrdenDeviceIdDpl =ordenDeviceIdDpl;
                        ordenObj.OrdenSerieDataPass =ordenSerieDataPass;
                        ordenObj.OrdenMacdataPass =ordenMacdataPass;
                        ordenObj.OrdenSerieTagreader =ordenSerieTagreader;
                        ordenObj.OrdenNroTagreader =ordenNroTagreader;
                        ordenObj.OrdenChip =ordenChip;
                        ordenObj.OrdenDivision =ordenDivision;
                        ordenObj.OrdenFlota =ordenFlota;
                        ordenObj.OrdenCardId =ordenCardId;
                        ordenObj.OrdenBobina =ordenBobina;
                        ordenObj.OrdenComentarioInicial =ordenComentarioInicial;
                        ordenObj.OrdenTrazaOrden =ordenTrazaOrden;
                        if (ordenInstalaDpl == "Sí")
                        {
                            ordenObj.OrdenInstalaDpl = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaDpl = false;
                        }

                        if (ordenInstalaDataPass == "Sí")
                        {
                            ordenObj.OrdenInstalaDataPass = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaDataPass = false;
                        }
                        
                        if (ordenInstalaTagreader == "Sí")
                        {
                            ordenObj.OrdenInstalaTagreader = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaTagreader = false;
                        }

                        if (ordenInstalaInmovilizador == "Sí")
                        {
                            ordenObj.OrdenInstalaInmovilizador = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaInmovilizador = false;
                        }


                        
                        ordenObj.OrdenLugar =ordenLugar;
                        ordenObj.OrdenZonaGira =ordenZonaGira;
                        ordenObj.OrdenNroParte =ordenNroParte;
                        ordenObj.OrdenCapacidadTanqueMim =ordenCapacidadTanqueMim;
                        ordenObj.OrdenCapacidadTanqueMimtec =ordenCapacidadTanqueMimtec;

                        if (ordenInstalaCa == "Sí")
                        {
                            ordenObj.OrdenInstalaCa = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaCa = false;
                        }
                        
                        if (ordenPudoInstalarCs == "Sí")
                        {
                            ordenObj.OrdenPudoInstalarCs = true;
                        }
                        else
                        {
                            ordenObj.OrdenPudoInstalarCs = false;
                        }

                        if (ordenInstalaMebiclick == "Sí")
                        {
                            ordenObj.OrdenInstalaMebiclick = true;
                        }
                        else
                        {
                            ordenObj.OrdenInstalaMebiclick = false;
                        }

                        if (ordenEncendidoPorMotor == "Sí")
                        {
                            ordenObj.OrdenEncendidoPorMotor = true;
                        }
                        else
                        {
                            ordenObj.OrdenEncendidoPorMotor = false;
                        }



                        //ordenObj.OrdenNumero = Convert.ToInt64(orden);
                        //ordenObj.OrdenFechaIngreso = Convert.ToDateTime(fechaIngreso);
                        //ordenObj.OrdenUsuarioNombre = usuarioIngreso;
                        //ordenObj.OrdenFechaInicioCoordinacion = Convert.ToDateTime(fechaCordInicio);
                        //ordenObj.OrdenFechaFinCoordinacion = Convert.ToDateTime(fechaCordFin);
                        //if (fechaFinalización != "")
                        //{
                        //    ordenObj.OrdenFechaFinalizacion = Convert.ToDateTime(fechaFinalización);
                        //}
                        //ordenObj.OrdenMovil = movil;
                        //ordenObj.OrdenLugar = lugar;
                        //ordenObj.OrdenEstado = estado;
                        //ordenObj.OrdenComentario = comentarios;

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
       // [HttpPost("{ordenes}")]

        //public IActionResult Get(List<ResponseOrden> ordenes)
        //{
        //    try
        //    {
        //        using (var workbook = new XLWorkbook())
        //        {
        //            var worksheet = workbook.Worksheets.Add("ordenes");
        //            var currentRow = 1;

        //            #region Header
        //            worksheet.Cell(currentRow, 1).Value = "Número";
        //            worksheet.Cell(currentRow, 2).Value = "Fecha Ingreso";
        //            worksheet.Cell(currentRow, 3).Value = "Usuario";
        //            worksheet.Cell(currentRow, 4).Value = "Fec. Ini Coord";
        //            worksheet.Cell(currentRow, 5).Value = "Fec. Fin Coord";
        //            worksheet.Cell(currentRow, 6).Value = "Fecha Finalización";
        //            worksheet.Cell(currentRow, 7).Value = "Móvil";
        //            worksheet.Cell(currentRow, 8).Value = "Lugar";
        //            worksheet.Cell(currentRow, 9).Value = "Comentario";
        //            worksheet.Cell(currentRow, 10).Value = "Empresa";
        //            worksheet.Cell(currentRow, 11).Value = "Funcionario";
        //            #endregion

        //            #region Body
        //            ordenes.ForEach(o =>
        //            {
        //                currentRow++;
        //                worksheet.Cell(currentRow, 1).Value = o.ordenNumero.ToString();
        //                worksheet.Cell(currentRow, 2).Value = o.ordenFechaIngreso?.ToString("dd/MM/yyyy HH:mm");
        //                worksheet.Cell(currentRow, 3).Value = o.ordenUsuarioNombre;
        //                worksheet.Cell(currentRow, 4).Value = o.ordenFechaInicioCoordinacion?.ToString("dd/MM/yyyy");
        //                worksheet.Cell(currentRow, 5).Value = o.ordenFechaFinCoordinacion?.ToString("dd/MM/yyyy");
        //                worksheet.Cell(currentRow, 6).Value = o.ordenFechaFinalizacion?.ToString("dd/MM/yyyy HH:mm");
        //                worksheet.Cell(currentRow, 7).Value = o.ordenMovil;
        //                worksheet.Cell(currentRow, 8).Value = o.ordenLugar;
        //                worksheet.Cell(currentRow, 9).Value = o.ordenComentario;
        //                worksheet.Cell(currentRow, 10).Value = o.ordenEmpresaNombre;
        //                worksheet.Cell(currentRow, 11).Value = o.ordenFuncionarioNombre + " " + o.ordenFuncionarioApellido;
        //                if (currentRow % 2 == 1)
        //                {
        //                    IXLRange range = worksheet.Range(worksheet.Cell(currentRow, 1).Address, worksheet.Cell(currentRow, 11).Address); //Las celdas del Header
        //                    range.Style.Fill.SetBackgroundColor(XLColor.LightBlue);
        //                }

        //            });
        //            #endregion

        //            // Selecciono un rango de celdas al cual aplicar estilos
        //            IXLRange range = worksheet.Range(worksheet.Cell(1, 1).Address, worksheet.Cell(1, 25).Address); //Las celdas del Header

        //            range.Style.Border.OutsideBorder = XLBorderStyleValues.Medium; //Borde
        //            range.Style.Font.SetBold(true); //Bold
        //            range.Style.Font.SetFontColor(XLColor.White);
        //            range.Style.Fill.SetBackgroundColor(XLColor.Red); //Backgroundcolor
        //            worksheet.RangeUsed().SetAutoFilter(); //Aplica filtro a cada columna
        //            worksheet.Columns().AdjustToContents();
        //            worksheet.Columns().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
        //            using (var stream = new MemoryStream())
        //            {
        //                workbook.SaveAs(stream);
        //                var content = stream.ToArray();

        //                String file = Convert.ToBase64String(content);
        //                return Ok(file);
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
