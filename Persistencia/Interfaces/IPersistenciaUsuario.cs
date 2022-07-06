using Sisconve.Models;
using System.Threading.Tasks;

namespace Sisconve.Persistencia.Interfaces
{
    public interface IPersistenciaUsuario
    {
        Task<Usuario> Login(string ci, string pass);
    }
}
