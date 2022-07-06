using System;
using System.Collections.Generic;

#nullable disable

namespace Sisconve.Models
{
    public partial class Usuario
    {
        public string UsuarioCi { get; set; }
        public string UsuarioNombres { get; set; }
        public string UsuarioApellidos { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioPassword { get; set; }
        public bool UsuarioEstado { get; set; }
    }
}
