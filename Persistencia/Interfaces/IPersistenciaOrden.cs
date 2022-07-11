﻿using Sisconve.Models;
using Sisconve.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sisconve.Persistencia.Interfaces
{
    public interface IPersistenciaOrden
    {
        Task<string> AgregarOrdenes(List<Orden> ordenes );
        Task<List<ResponseOrden>> ListarOrdenes(string tipo, string fechaDesde, string fechaHasta);
    }
}
