using System;

namespace Sisconve.Models.Response
{
    public class ResponseOrden
    {
        public long ordenId { get; set; }
        public long? ordenNumero { get; set; }
        public DateTime? ordenFechaIngreso { get; set; }
        public string ordenUsuarioNombre { get; set; }
        public DateTime? ordenFechaInicioCoordinacion { get; set; }
        public DateTime? ordenFechaFinCoordinacion { get; set; }
        public DateTime? ordenFechaFinalizacion { get; set; }
        public string ordenMovil { get; set; }
        public string ordenLugar { get; set; }
        public string ordenEstado { get; set; }
        public string ordenComentario { get; set; }
        public int? ordenEmpresaId { get; set; }
        public string ordenEmpresaNombre { get; set; }
        public int? ordenFuncionarioId { get; set; }
        public string ordenFuncionarioNombre { get; set; }
        public string ordenFuncionarioApellido { get; set; }
    }
}
