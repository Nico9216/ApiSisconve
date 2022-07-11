using System;
using System.Collections.Generic;

#nullable disable

namespace Sisconve.Models
{
    public partial class Orden
    {
        public long OrdenId { get; set; }
        public long? OrdenNumero { get; set; }
        public DateTime? OrdenFechaIngreso { get; set; }
        public string OrdenUsuarioNombre { get; set; }
        public DateTime? OrdenFechaInicioCoordinacion { get; set; }
        public DateTime? OrdenFechaFinCoordinacion { get; set; }
        public DateTime? OrdenFechaFinalizacion { get; set; }
        public string OrdenMovil { get; set; }
        public string OrdenLugar { get; set; }
        public string OrdenEstado { get; set; }
        public string OrdenComentario { get; set; }
        public int? OrdenEmpresaId { get; set; }
        public string OrdenEmpresaNombre { get; set; }
        public int? OrdenFuncionarioId { get; set; }
        public string OrdenFuncionarioNombre { get; set; }
        public string OrdenFuncionarioApellido { get; set; }

        public virtual Empresa OrdenEmpresa { get; set; }
        public virtual Funcionario OrdenFuncionarioNavigation { get; set; }
    }
}
