using Sisconve.Models;
using Sisconve.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sisconve.Persistencia.Interfaces
{
    public interface IPersistenciaEmpresa
    {
        Task<List<ResponseEmpresa>> ListarEmpresas();
    }
}
