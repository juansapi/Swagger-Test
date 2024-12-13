using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserRequest> _users = new();

        public void AgregarUsuario(UserRequest user)
        {
            _users.Add(user);
        }

        public List<UserRequest> ObtenerTodosLosUsuarios()
        {
            return _users;
        }
    }
}
