namespace PruebaTecnica.Services
{
    public class MessageService : IMessageService
    {
        public void EnviarMensaje(string nombre, string telefono)
        {
            Console.WriteLine($"Mensaje de bienvenida enviado a {nombre} al número {telefono}");
        }
    }
}
