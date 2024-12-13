using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public interface IUserRepository
    {
        void AgregarUsuario(UserRequest user);
        List<UserRequest> ObtenerTodosLosUsuarios();
    }
}