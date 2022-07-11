using System;
using System.Collections.Generic;

#nullable disable

namespace Sisconve.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Funcionarios = new HashSet<Funcionario>();
            Ordens = new HashSet<Orden>();
        }

        public int EmpresaId { get; set; }
        public string EmpresaNombre { get; set; }
        public int EmpresaCantServDiario { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
