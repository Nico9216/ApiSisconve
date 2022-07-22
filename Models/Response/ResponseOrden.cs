using System;

namespace Sisconve.Models.Response
{
    public class ResponseOrden
    {
        public long ordenId { get; set; }
        public long? ordenNumero { get; set; }
        public string ordenNombreOrganizacion { get; set; }
        public string ordenMovil { get; set; }
        public string ordenMatricula { get; set; }
        public string ordenEstado { get; set; }
        public DateTime? ordenFechaInicioCoordinacion { get; set; }
        public DateTime? ordenFechaFinCoordinacion { get; set; }
        public DateTime? ordenFechaFinalizacion { get; set; }
        public string ordenUsuarioNombreFinalizo { get; set; }
        public string ordenTmpoTrabajoEnMdeo { get; set; }
        public string ordenTmpoTrabajoEnInterior { get; set; }
        public DateTime? ordenFechaPrimeraCarga { get; set; }
        public string ordenSerieDpl { get; set; }
        public string ordenDeviceIdDpl { get; set; }
        public string ordenSerieDataPass { get; set; }
        public string ordenMacdataPass { get; set; }
        public string ordenSerieTagreader { get; set; }
        public string ordenNroTagreader { get; set; }
        public string ordenChip { get; set; }
        public string ordenDivision { get; set; }
        public string ordenFlota { get; set; }
        public string ordenCardId { get; set; }
        public string ordenBobina { get; set; }
        public string ordenComentarioInicial { get; set; }
        public string ordenTrazaOrden { get; set; }
        public bool ordenInstalaDpl { get; set; }
        public bool ordenInstalaDataPass { get; set; }
        public bool ordenInstalaTagreader { get; set; }
        public bool ordenInstalaInmovilizador { get; set; }
        public string ordenLugar { get; set; }
        public string ordenDescripcion { get; set; }
        public string ordenZonaGira { get; set; }
        public string ordenNroParte { get; set; }
        public string ordenCapacidadTanqueMim { get; set; }
        public string ordenCapacidadTanqueMimtec { get; set; }
        public bool ordenInstalaCa { get; set; }
        public bool ordenPudoInstalarCs { get; set; }
        public bool ordenInstalaMebiclick { get; set; }
        public bool ordenEncendidoPorMotor { get; set; }
        public string ordenComentarioFinales { get; set; }
        public string ordenUsuarioAsigna { get; set; }
        public string ordenEmpresaAsignadaNombre { get; set; }
        public DateTime? ordenFechaAsignacion { get; set; }
    }
}
