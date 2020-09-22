
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsUsuario
    {
        Task<int> agregarUsuario(Usuario usuario);
        Task<int> actualizarUsuario(Usuario usuario);
        Task<int> eliminarUsuario(long idUsuario);
        Task<List<Usuario>> obtenerUsuarios();

    }
}
