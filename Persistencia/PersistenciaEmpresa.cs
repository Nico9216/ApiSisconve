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
    public class PersistenciaEmpresa: IPersistenciaEmpresa
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
                            EmpresaId=o.EmpresaId,
                            EmpresaNombre=o.EmpresaNombre,
                            EmpresaCantServDiario=o.EmpresaCantServDiario,
                        }).ToListAsync();
                    
                  

                    return empresas;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.Message);
                }
            }
        }
    }
}
