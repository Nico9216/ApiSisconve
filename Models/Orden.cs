using System;
using System.Collections.Generic;

#nullable disable

namespace Sisconve.Models
{
    public partial class Orden
    {
        public long OrdenId { get; set; }
        public long? OrdenNumero { get; set; }
        public string OrdenNombreOrganizacion { get; set; }
        public string OrdenMovil { get; set; }
        public string OrdenMatricula { get; set; }
        public string OrdenEstado { get; set; }
        public DateTime? OrdenFechaInicioCoordinacion { get; set; }
        public DateTime? OrdenFechaFinCoordinacion { get; set; }
        public DateTime? OrdenFechaFinalizacion { get; set; }
        public string OrdenUsuarioNombreFinalizo { get; set; }
        public string OrdenTmpoTrabajoEnMdeo { get; set; }
        public string OrdenTmpoTrabajoEnInterior { get; set; }
        public DateTime? OrdenFechaPrimeraCarga { get; set; }
        public string OrdenSerieDpl { get; set; }
        public string OrdenDeviceIdDpl { get; set; }
        public string OrdenSerieDataPass { get; set; }
        public string OrdenMacdataPass { get; set; }
        public string OrdenSerieTagreader { get; set; }
        public string OrdenNroTagreader { get; set; }
        public string OrdenChip { get; set; }
        public string OrdenDivision { get; set; }
        public string OrdenFlota { get; set; }
        public string OrdenCardId { get; set; }
        public string OrdenBobina { get; set; }
        public string OrdenComentarioInicial { get; set; }
        public string OrdenTrazaOrden { get; set; }
        public bool OrdenInstalaDpl { get; set; }
        public bool OrdenInstalaDataPass { get; set; }
        public bool OrdenInstalaTagreader { get; set; }
        public bool OrdenInstalaInmovilizador { get; set; }
        public string OrdenLugar { get; set; }
        public string OrdenDescripcion { get; set; }
        public string OrdenZonaGira { get; set; }
        public string OrdenNroParte { get; set; }
        public string OrdenCapacidadTanqueMim { get; set; }
        public string OrdenCapacidadTanqueMimtec { get; set; }
        public bool OrdenInstalaCa { get; set; }
        public bool OrdenPudoInstalarCs { get; set; }
        public bool OrdenInstalaMebiclick { get; set; }
        public bool OrdenEncendidoPorMotor { get; set; }
        public string OrdenComentarioFinales { get; set; }
    }
}
