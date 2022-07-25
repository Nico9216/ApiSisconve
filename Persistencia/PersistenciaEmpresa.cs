using Sisconve.Models;
using Sisconve.Persistencia.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Sisconve.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Sisconve.Persistencia
{
    public class PersistenciaEmpresa :IPersistenciaEmpresa
    {
        public async Task<List<ResponseEmpresa>> ListarEmpresas()
        {
            using (var _context = new SisconveContext())
            {
                try
                {

                    List<ResponseEmpresa> empresas = new List<ResponseEmpresa>();

                    empresas = await _context.Empresas.Select(o => new ResponseEmpresa
                        {
                            empresaId=o.EmpresaId,
                            empresaNombre=o.EmpresaNombre,
                            empresaCantEmpleados=o.EmpresaCantEmpleados,
                            empresaHorarioInicio=o.EmpresaHorarioInicio,
                            empresaHorarioFin=o.EmpresaHorarioFin,
                        }).ToListAsync();
                    
                  

                    return empresas;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public async Task<string> AgregarEmpresa([FromBody]ResponseEmpresa empresa)
        {
            using (var _context = new SisconveContext())
            {
                try
                {
                    Empresa empresaContext = new Empresa();
                   
                    empresaContext.EmpresaNombre = empresa.empresaNombre;
                    empresaContext.EmpresaCantEmpleados = empresa.empresaCantEmpleados;
                    empresaContext.EmpresaHorarioInicio = empresa.empresaHorarioInicio;
                    empresaContext.EmpresaHorarioFin = empresa.empresaHorarioFin;
                    empresaContext.EmpresaEstado = false;

                    _context.Empresas.Add(empresaContext);
                    await _context.SaveChangesAsync();

                    return "Ok";
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public async Task<string> ModificarEmpresa( ResponseEmpresa empresa)
        {
            using (var _context = new SisconveContext())
            {
                try
                {
                    Empresa empresaContext = new Empresa();
                    empresaContext.EmpresaId = empresa.empresaId;
                    empresaContext.EmpresaNombre = empresa.empresaNombre;
                    empresaContext.EmpresaCantEmpleados = empresa.empresaCantEmpleados;
                    empresaContext.EmpresaHorarioInicio = empresa.empresaHorarioInicio;
                    empresaContext.EmpresaHorarioFin = empresa.empresaHorarioFin;

                    _context.Update<Empresa>(empresaContext);
                    await _context.SaveChangesAsync();

                    return "Ok";
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }

        public async Task<ResponseEmpresa> BuscarEmpresa(int id)
        {
            using (var _context = new SisconveContext())
            {
                try
                {
                    Empresa empresaContext = empresaContext= await _context.Empresas.Where(e=>e.EmpresaId==id).FirstOrDefaultAsync();
                    
                    ResponseEmpresa empresa = new ResponseEmpresa();
                    empresa.empresaId = empresaContext.EmpresaId;
                    empresa.empresaNombre = empresaContext.EmpresaNombre;
                    empresa.empresaCantEmpleados= empresaContext.EmpresaCantEmpleados;
                    empresa.empresaHorarioInicio= empresaContext.EmpresaHorarioInicio;
                    empresa.empresaHorarioFin= empresaContext.EmpresaHorarioFin;
                   

                    return empresa;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }
    }
}
