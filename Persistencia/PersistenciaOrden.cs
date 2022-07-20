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
                        ordenes = await _context.Ordens.Where(o =>  o.OrdenFechaIngreso >= fechaIni && o.OrdenFechaIngreso <=fechaFin).Select(o=> new ResponseOrden
                        {
                            ordenId = o.OrdenId,
                            ordenNumero = o.OrdenNumero,
                            ordenFechaIngreso=o.OrdenFechaIngreso,
                            ordenUsuarioNombre=o.OrdenUsuarioNombre,
                            ordenFechaInicioCoordinacion=o.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion=o.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion=o.OrdenFechaFinalizacion,
                            ordenMovil=o.OrdenMovil,
                            ordenLugar=o.OrdenLugar,
                            ordenEstado=o.OrdenEstado,
                            ordenComentario=o.OrdenComentario,
                            ordenEmpresaId=o.OrdenEmpresaId,
                            ordenEmpresaNombre=o.OrdenEmpresaNombre,
                            ordenFuncionarioId=o.OrdenFuncionarioId,
                            ordenFuncionarioNombre= o.OrdenFuncionarioNombre,
                            ordenFuncionarioApellido=o.OrdenFuncionarioApellido
                        }).ToListAsync();
                    }
                    else
                    {
                        //&& o.OrdenFechaIngreso >= fechaIni && o.OrdenFechaIngreso <= fechaFin
                        ordenes = await _context.Ordens.Where(o => o.OrdenEstado == tipo ).Select(o => new ResponseOrden
                        {
                            ordenId = o.OrdenId,
                            ordenNumero = o.OrdenNumero,
                            ordenFechaIngreso = o.OrdenFechaIngreso,
                            ordenUsuarioNombre = o.OrdenUsuarioNombre,
                            ordenFechaInicioCoordinacion = o.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion = o.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion = o.OrdenFechaFinalizacion,
                            ordenMovil = o.OrdenMovil,
                            ordenLugar = o.OrdenLugar,
                            ordenEstado = o.OrdenEstado,
                            ordenComentario = o.OrdenComentario,
                            ordenEmpresaId = o.OrdenEmpresaId,
                            ordenEmpresaNombre = o.OrdenEmpresaNombre,
                            ordenFuncionarioId = o.OrdenFuncionarioId,
                            ordenFuncionarioNombre = o.OrdenFuncionarioNombre,
                            ordenFuncionarioApellido = o.OrdenFuncionarioApellido
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
                        Orden orden = new Orden();
                        orden= await _context.Ordens.Where(o => o.OrdenId == ordenId).FirstOrDefaultAsync();
                        orden.OrdenEstado = "Asignado";
                         _context.Ordens.Update(orden);
                        ResponseOrden ordenResponse = new ResponseOrden
                        {
                            ordenId = orden.OrdenId,
                            ordenNumero = orden.OrdenNumero,
                            ordenFechaIngreso = orden.OrdenFechaIngreso,
                            ordenUsuarioNombre = orden.OrdenUsuarioNombre,
                            ordenFechaInicioCoordinacion = orden.OrdenFechaInicioCoordinacion,
                            ordenFechaFinCoordinacion = orden.OrdenFechaFinCoordinacion,
                            ordenFechaFinalizacion = orden.OrdenFechaFinalizacion,
                            ordenMovil = orden.OrdenMovil,
                            ordenLugar = orden.OrdenLugar,
                            ordenEstado = orden.OrdenEstado,
                            ordenComentario = orden.OrdenComentario,
                            ordenEmpresaId = orden.OrdenEmpresaId,
                            ordenEmpresaNombre = orden.OrdenEmpresaNombre,
                            ordenFuncionarioId = orden.OrdenFuncionarioId,
                            ordenFuncionarioNombre = orden.OrdenFuncionarioNombre,
                            ordenFuncionarioApellido = orden.OrdenFuncionarioApellido
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
