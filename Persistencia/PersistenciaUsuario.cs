using Sisconve.Models;
using Sisconve.Persistencia.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Sisconve.Persistencia
{
    public class PersistenciaUsuario:IPersistenciaUsuario
    {
        public async Task<Usuario> Login(string ci, string pass)
        {
            try
            {
                Usuario usu = null;
                using (var _context = new SisconveContext())
                {

                    usu = await _context.Usuarios.Where(x => x.UsuarioCi == ci && x.UsuarioPassword==pass).FirstOrDefaultAsync(); 
                }
                return usu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
