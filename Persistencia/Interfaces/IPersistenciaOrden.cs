using Sisconve.Models;
using Sisconve.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sisconve.Persistencia.Interfaces
{
    public interface IPersistenciaOrden
    {
        Task<string> AgregarOrdenes(List<Orden> ordenes );
        Task<List<ResponseOrden>> ListarOrdenes(string tipo, string fechaDesde, string fechaHasta);
        Task<List<ResponseOrden>> AsignarOrdenes(List<int> ordenes, int idEMpresa);
        Task<List<ResponseOrden>> ListarOrdenesPorEmpresa(string fecha);
        Task<string> FinalizarOrdenes(List<Orden> ordenes);
    }
}
