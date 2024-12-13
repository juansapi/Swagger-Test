using Xunit;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Controllers;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;
using PruebaTecnica.Services;

// Verifica que el controlador maneje correctamente las solicitudes POST y valide los datos.

public class UsersControllerTests
{
    // Prueba cuando se envían datos válidos,
    // la API devuelve un mensaje de éxito.
    [Fact]
    public void RegistrarUsuario_NumeroValido_RetornaResultadoExitoso()
    {
        // Arrange
        var repository = new UserRepository();
        var service = new MessageService();
        var controller = new UsersController(repository, service);

        // Solicitud Correcta
        var userRequest = new UserRequest
        {
            Nombre = "Juan David",
            Telefono = "3225229032"
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    // Prueba cuando el Nombre está vacío,
    // se devuelve un BadRequest con el mensaje adecuado.
    [Fact]
    public void RegistrarUsuario_SinNombre_RetornaBadRequest()
    {
        // Arrange
        var repository = new UserRepository();
        var service = new MessageService();
        var controller = new UsersController(repository, service);

        // Solicitud con el Nombre vacío
        var userRequest = new UserRequest
        {
            Nombre = "",
            Telefono = "3225229032"
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El nombre y el número de teléfono son obligatorios.", badRequestResult.Value);
    }

    // Prueba cuando el Telefono está vacío,
    // se devuelve un BadRequest con el mensaje adecuado.
    [Fact]
    public void RegistrarUsuario_SinTelefono_RetornaBadRequest()
    {
        // Arrange
        var repository = new UserRepository();
        var service = new MessageService();
        var controller = new UsersController(repository, service);

        // Solicitud con el teléfono vacío
        var userRequest = new UserRequest
        {
            Nombre = "Juan David",
            Telefono = "" 
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El nombre y el número de teléfono son obligatorios.", badRequestResult.Value);
    }

    // Prueba cuando el Nombre y Telefono están vacíos,
    // la API devuelve un BadRequest con el mensaje adecuado.
    [Fact]
    public void RegistrarUsuario_SinNombreSinTelefono_RetornaBadRequest()
    {
        // Arrange
        var repository = new UserRepository(); 
        var service = new MessageService(); 
        var controller = new UsersController(repository, service);

        // Solicitud con nombre y teléfono vacíos
        var userRequest = new UserRequest
        {
            Nombre = "",
            Telefono = "" 
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El nombre y el número de teléfono son obligatorios.", badRequestResult.Value);
    }

    // Prueba cuando el número de teléfono contiene letras
    // o caracteres no válidos, se devuelve un BadRequest.
    [Fact]
    public void RegistrarUsuario_NumeroTelefonoInvalido_RetornaBadRequest()
    {
        // Arrange
        var repository = new UserRepository();
        var service = new MessageService();
        var controller = new UsersController(repository, service);
        
        var userRequest = new UserRequest
        {
            Nombre = "Juan David",
            Telefono = "ABC322589VC"
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("El número de teléfono contiene caracteres no válidos.", badRequestResult.Value);
    }

    // Prueba cuando el número de teléfono contiene caracteres especiales válidos
    [Fact]
    public void RegistrarUsuario_NumeroValidoConCaracteresEspeciales_RetornaResultadoExitoso()
    {
        // Arrange
        var repository = new UserRepository();
        var service = new MessageService();
        var controller = new UsersController(repository, service);
        
        var userRequest = new UserRequest
        {
            Nombre = "Juan David",
            Telefono = "+1-200-555-1777"
        };

        // Act
        var result = controller.RegistrarUsuario(userRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}
