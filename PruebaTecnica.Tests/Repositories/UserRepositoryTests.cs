using Xunit;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

// Verifica que el repositorio almacene correctamente los usuarios en la memoria.

public class UserRepositoryTests
{
    [Fact]
    public void AgregarUsuario_UsuarioValido_UsuarioEsAgregado()
    {
        // Arrange
        var repository = new UserRepository();
        var user = new UserRequest { Nombre = "Juan David", Telefono = "3225229032" };

        // Act
        repository.AgregarUsuario(user);

        // Assert
        var users = repository.ObtenerTodosLosUsuarios();
        Assert.Single(users);
        Assert.Equal("Juan David", users[0].Nombre);
        Assert.Equal("3225229032", users[0].Telefono);
    }
}
