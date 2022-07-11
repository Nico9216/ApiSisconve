using System;
using System.Collections.Generic;

#nullable disable

namespace Sisconve.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Ordens = new HashSet<Orden>();
        }

        public int FuncionarioId { get; set; }
        public string FuncionarioNombre { get; set; }
        public string FuncionarioApellido { get; set; }
        public string FuncionarioCargo { get; set; }
        public int? FuncionarioEmpresaId { get; set; }
        public string FuncionarioEstado { get; set; }

        public virtual Empresa FuncionarioEmpresa { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
