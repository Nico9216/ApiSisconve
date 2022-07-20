namespace Sisconve.Models.Response
{
    public class ResponseEmpresa
    {
        public int empresaId { get; set; }
        public string empresaNombre { get; set; }
        public int? empresaCantEmpleados { get; set; }
        public int? empresaHorarioInicio { get; set; }
        public int? empresaHorarioFin { get; set; }

    }
}
