using System.Text.RegularExpressions;

namespace PruebaTecnica.Models
{
    public class UserRequest
    {
        public required string Nombre { get; set; }
        public required string Telefono { get; set; }

        // Excluir letras dentro del telefono.
        // Permitiendo números, espacios, +, y guiones.
        public bool EsNumeroDeTelefonoValido()
        {            
            var regex = new Regex(@"^[\d\s\+\-]*$");
            return regex.IsMatch(Telefono);
        }

    }
}
