using Sisconve.Models;
using Sisconve.Persistencia.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Sisconve.Models.Response;


namespace Sisconve.Persistencia
{
    public class PersistenciaOrden : IPersistenciaOrden
    {
        public async Task<string> AgregarOrdenes(List<Orden> ordenes)
        {
            using (var _context = new SisconveContext())
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (Orden orden in ordenes)
                        {
                            Orden ordenExiste = await _context.Ordens.Where(x => x.OrdenNumero == orden.OrdenNumero).FirstOrDefaultAsync();
                            if(ordenExiste != null)
                            {
                                throw new Exception("Ya fue cargada una orden con el número "+ orden.OrdenNumero.ToString());
                            }
                            _context.Add(orden);
                            await _context.SaveChangesAsync();
                        }

                        transaction.Commit();
                        return "Ok";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new ApplicationException(ex.Message);
                       
                    }
                }
            }
           
        }

        public async Task<List<ResponseOrden>> ListarOrdenes(string tipo, string fechaDesde, string fechaHasta)
        {
            using (var _context = new SisconveContext())
            {
                try
                {
                    DateTime fechaIni=Convert.ToDateTime(fechaDesde);
                    DateTime fechaFin=Convert.ToDateTime(fechaHasta);   
                    List<ResponseOrden> ordenes = new List<ResponseOrden>();
                    if (tipo == "Todos")
                    {
                        ordenes = await _context.Ordens.Where(o =>  o.OrdenFechaInicioCoordinacion >= fechaIni && o.OrdenFechaInicioCoordinacion <= fechaFin).Select(o=> new ResponseOrden
                        {
                            ordenId = o.OrdenId,
                            ordenNumero = o.OrdenNumero,
                            ordenNombreOrganizacion = o.OrdenNombreOrganizacion,
                            ordenMovil = o.OrdenMovil,
                            ordenMatricula = o.OrdenMatricula,
                            ordenEstado = o.OrdenEstado,
                            ordenFechaInicioCoordinacion = o.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion = o.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion = o.OrdenFechaFinalizacion,
                            ordenUsuarioNombreFinalizo = o.OrdenUsuarioNombreFinalizo,
                            ordenTmpoTrabajoEnMdeo = o.OrdenTmpoTrabajoEnMdeo,
                            ordenTmpoTrabajoEnInterior = o.OrdenTmpoTrabajoEnInterior,
                            ordenFechaPrimeraCarga = o.OrdenFechaPrimeraCarga,
                            ordenSerieDpl = o.OrdenSerieDpl,
                            ordenDeviceIdDpl = o.OrdenDeviceIdDpl,
                            ordenSerieDataPass=o.OrdenSerieDataPass,
                            ordenMacdataPass=o.OrdenMacdataPass,
                            ordenSerieTagreader = o.OrdenSerieTagreader,
                            ordenNroTagreader = o.OrdenNroTagreader,
                            ordenChip=o.OrdenChip,
                            ordenDivision=o.OrdenDivision,
                            ordenFlota=o.OrdenFlota,
                            ordenCardId=o.OrdenCardId,
                            ordenBobina=o.OrdenBobina,
                            ordenComentarioInicial=o.OrdenComentarioInicial,
                            ordenTrazaOrden= o.OrdenTrazaOrden,
                            ordenInstalaDpl=o.OrdenInstalaDpl,
                            ordenInstalaDataPass=o.OrdenInstalaDataPass,
                            ordenInstalaTagreader = o.OrdenInstalaTagreader,
                            ordenInstalaInmovilizador=o.OrdenInstalaInmovilizador,
                            ordenLugar=o.OrdenLugar,
                            ordenZonaGira=o.OrdenZonaGira,
                            ordenNroParte=o.OrdenNroParte,
                            ordenCapacidadTanqueMim=o.OrdenCapacidadTanqueMim,
                            ordenCapacidadTanqueMimtec=o.OrdenCapacidadTanqueMimtec,
                            ordenInstalaCa=o.OrdenInstalaCa,
                            ordenPudoInstalarCs=o.OrdenPudoInstalarCs,
                            ordenInstalaMebiclick=o.OrdenInstalaMebiclick,
                            ordenEncendidoPorMotor=o.OrdenEncendidoPorMotor,
                            ordenComentarioFinales=o.OrdenComentarioFinales
                        }).ToListAsync();
                    }
                    else
                    {
                        //&& o.OrdenFechaIngreso >= fechaIni && o.OrdenFechaIngreso <= fechaFin
                        ordenes = await _context.Ordens.Where(o => o.OrdenEstado == tipo ).Select(o => new ResponseOrden
                        {
                            ordenId = o.OrdenId,
                            ordenNumero = o.OrdenNumero,
                            ordenNombreOrganizacion = o.OrdenNombreOrganizacion,
                            ordenMovil = o.OrdenMovil,
                            ordenMatricula = o.OrdenMatricula,
                            ordenEstado = o.OrdenEstado,
                            ordenFechaInicioCoordinacion = o.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion = o.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion = o.OrdenFechaFinalizacion,
                            ordenUsuarioNombreFinalizo = o.OrdenUsuarioNombreFinalizo,
                            ordenTmpoTrabajoEnMdeo = o.OrdenTmpoTrabajoEnMdeo,
                            ordenTmpoTrabajoEnInterior = o.OrdenTmpoTrabajoEnInterior,
                            ordenFechaPrimeraCarga = o.OrdenFechaPrimeraCarga,
                            ordenSerieDpl = o.OrdenSerieDpl,
                            ordenDeviceIdDpl = o.OrdenDeviceIdDpl,
                            ordenSerieDataPass = o.OrdenSerieDataPass,
                            ordenMacdataPass = o.OrdenMacdataPass,
                            ordenSerieTagreader = o.OrdenSerieTagreader,
                            ordenNroTagreader = o.OrdenNroTagreader,
                            ordenChip = o.OrdenChip,
                            ordenDivision = o.OrdenDivision,
                            ordenFlota = o.OrdenFlota,
                            ordenCardId = o.OrdenCardId,
                            ordenBobina = o.OrdenBobina,
                            ordenComentarioInicial = o.OrdenComentarioInicial,
                            ordenTrazaOrden = o.OrdenTrazaOrden,
                            ordenInstalaDpl = o.OrdenInstalaDpl,
                            ordenInstalaDataPass = o.OrdenInstalaDataPass,
                            ordenInstalaTagreader = o.OrdenInstalaTagreader,
                            ordenInstalaInmovilizador = o.OrdenInstalaInmovilizador,
                            ordenLugar = o.OrdenLugar,
                            ordenZonaGira = o.OrdenZonaGira,
                            ordenNroParte = o.OrdenNroParte,
                            ordenCapacidadTanqueMim = o.OrdenCapacidadTanqueMim,
                            ordenCapacidadTanqueMimtec = o.OrdenCapacidadTanqueMimtec,
                            ordenInstalaCa = o.OrdenInstalaCa,
                            ordenPudoInstalarCs = o.OrdenPudoInstalarCs,
                            ordenInstalaMebiclick = o.OrdenInstalaMebiclick,
                            ordenEncendidoPorMotor = o.OrdenEncendidoPorMotor,
                            ordenComentarioFinales = o.OrdenComentarioFinales
                        }).ToListAsync();
                    }

                    return ordenes;
                }
                catch(Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public async Task<List<ResponseOrden>> AsignarOrdenes(List<int> ordenes, int idEMpresa)
        {
            using (var _context = new SisconveContext())
            {
                try
                {

                    List<ResponseOrden> ordenesLista = new List<ResponseOrden>();

                    foreach(var ordenId in ordenes)
                    {
                        Orden o = new Orden();
                        o= await _context.Ordens.Where(o => o.OrdenId == ordenId).FirstOrDefaultAsync();
                        o.OrdenEstado = "Asignado";
                         _context.Ordens.Update(o);
                        ResponseOrden ordenResponse = new ResponseOrden
                        {
                            ordenId = o.OrdenId,
                            ordenNumero = o.OrdenNumero,
                            ordenNombreOrganizacion = o.OrdenNombreOrganizacion,
                            ordenMovil = o.OrdenMovil,
                            ordenMatricula = o.OrdenMatricula,
                            ordenEstado = o.OrdenEstado,
                            ordenFechaInicioCoordinacion = o.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion = o.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion = o.OrdenFechaFinalizacion,
                            ordenUsuarioNombreFinalizo = o.OrdenUsuarioNombreFinalizo,
                            ordenTmpoTrabajoEnMdeo = o.OrdenTmpoTrabajoEnMdeo,
                            ordenTmpoTrabajoEnInterior = o.OrdenTmpoTrabajoEnInterior,
                            ordenFechaPrimeraCarga = o.OrdenFechaPrimeraCarga,
                            ordenSerieDpl = o.OrdenSerieDpl,
                            ordenDeviceIdDpl = o.OrdenDeviceIdDpl,
                            ordenSerieDataPass = o.OrdenSerieDataPass,
                            ordenMacdataPass = o.OrdenMacdataPass,
                            ordenSerieTagreader = o.OrdenSerieTagreader,
                            ordenNroTagreader = o.OrdenNroTagreader,
                            ordenChip = o.OrdenChip,
                            ordenDivision = o.OrdenDivision,
                            ordenFlota = o.OrdenFlota,
                            ordenCardId = o.OrdenCardId,
                            ordenBobina = o.OrdenBobina,
                            ordenComentarioInicial = o.OrdenComentarioInicial,
                            ordenTrazaOrden = o.OrdenTrazaOrden,
                            ordenInstalaDpl = o.OrdenInstalaDpl,
                            ordenInstalaDataPass = o.OrdenInstalaDataPass,
                            ordenInstalaTagreader = o.OrdenInstalaTagreader,
                            ordenInstalaInmovilizador = o.OrdenInstalaInmovilizador,
                            ordenLugar = o.OrdenLugar,
                            ordenZonaGira = o.OrdenZonaGira,
                            ordenNroParte = o.OrdenNroParte,
                            ordenCapacidadTanqueMim = o.OrdenCapacidadTanqueMim,
                            ordenCapacidadTanqueMimtec = o.OrdenCapacidadTanqueMimtec,
                            ordenInstalaCa = o.OrdenInstalaCa,
                            ordenPudoInstalarCs = o.OrdenPudoInstalarCs,
                            ordenInstalaMebiclick = o.OrdenInstalaMebiclick,
                            ordenEncendidoPorMotor = o.OrdenEncendidoPorMotor,
                            ordenComentarioFinales = o.OrdenComentarioFinales
                        };
                        ordenesLista.Add(ordenResponse);
                        await _context.SaveChangesAsync();

                    }

                    return ordenesLista;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }
    }
}
