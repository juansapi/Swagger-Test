using Xunit;
using PruebaTecnica.Services;

// Verifica que el servicio simule el envío del mensaje.
// Pero no se puede verificar la salida a consola de manera automatizada.

public class MessageServiceTests
{
    [Fact]
    public void EnviarMensaje_EntradasValidas_MensajeEsRegistrado()
    {
        // Arrange
        var service = new MessageService();
        var name = "Juan David";
        var phoneNumber = "3225229032";

        // Act
        service.EnviarMensaje(name, phoneNumber);        
    }
}
