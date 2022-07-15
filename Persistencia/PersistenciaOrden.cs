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
                            OrdenId = o.OrdenId,
                            OrdenNumero = o.OrdenNumero,
                            OrdenFechaIngreso=o.OrdenFechaIngreso,
                            OrdenUsuarioNombre=o.OrdenUsuarioNombre,
                            OrdenFechaInicioCoordinacion=o.OrdenFechaInicioCoordinacion,
                            OrdenFechaFinCoordinacion=o.OrdenFechaFinCoordinacion,
                            OrdenFechaFinalizacion=o.OrdenFechaFinalizacion,
                            OrdenMovil=o.OrdenMovil,
                            OrdenLugar=o.OrdenLugar,
                            OrdenEstado=o.OrdenEstado,
                            OrdenComentario=o.OrdenComentario,
                            OrdenEmpresaId=o.OrdenEmpresaId,
                            OrdenEmpresaNombre=o.OrdenEmpresaNombre,
                            OrdenFuncionarioId=o.OrdenFuncionarioId,
                            OrdenFuncionarioNombre= o.OrdenFuncionarioNombre,
                            OrdenFuncionarioApellido=o.OrdenFuncionarioApellido
                        }).ToListAsync();
                    }
                    else
                    {
                        //&& o.OrdenFechaIngreso >= fechaIni && o.OrdenFechaIngreso <= fechaFin
                        ordenes = await _context.Ordens.Where(o => o.OrdenEstado == tipo ).Select(o => new ResponseOrden
                        {
                            OrdenId = o.OrdenId,
                            OrdenNumero = o.OrdenNumero,
                            OrdenFechaIngreso = o.OrdenFechaIngreso,
                            OrdenUsuarioNombre = o.OrdenUsuarioNombre,
                            OrdenFechaInicioCoordinacion = o.OrdenFechaInicioCoordinacion,
                            OrdenFechaFinCoordinacion = o.OrdenFechaFinCoordinacion,
                            OrdenFechaFinalizacion = o.OrdenFechaFinalizacion,
                            OrdenMovil = o.OrdenMovil,
                            OrdenLugar = o.OrdenLugar,
                            OrdenEstado = o.OrdenEstado,
                            OrdenComentario = o.OrdenComentario,
                            OrdenEmpresaId = o.OrdenEmpresaId,
                            OrdenEmpresaNombre = o.OrdenEmpresaNombre,
                            OrdenFuncionarioId = o.OrdenFuncionarioId,
                            OrdenFuncionarioNombre = o.OrdenFuncionarioNombre,
                            OrdenFuncionarioApellido = o.OrdenFuncionarioApellido
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
    }
}
