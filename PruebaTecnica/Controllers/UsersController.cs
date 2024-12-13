using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;
using PruebaTecnica.Services;

namespace PruebaTecnica.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageService _messageService;

        public UsersController(IUserRepository userRepository, IMessageService messageService)
        {
            _userRepository = userRepository;
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult RegistrarUsuario([FromBody] UserRequest userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.Nombre) || string.IsNullOrEmpty(userRequest.Telefono))
            {
                return BadRequest("El nombre y el número de teléfono son obligatorios.");
            }

            if (!userRequest.EsNumeroDeTelefonoValido())
            {
                return BadRequest("El número de teléfono contiene caracteres no válidos.");
            }

            _userRepository.AgregarUsuario(userRequest);
            
            _messageService.EnviarMensaje(userRequest.Nombre, userRequest.Telefono);

            return Ok(new { message = "Usuario registrado y mensaje enviado correctamente." });
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosUsuarios()
        {
            var users = _userRepository.ObtenerTodosLosUsuarios();
            return Ok(users);
        }
    }

}
