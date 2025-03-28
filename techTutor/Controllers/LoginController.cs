using Microsoft.AspNetCore.Mvc;
using techTutor.Domain.Entity;
using techTutor.Domain.Interfaces;

namespace techTutor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login; 
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (_login.GetLogin(usuario))  // Verifica se o usuário já existe
            {
                return Ok(new { message = "Login bem-sucedido" }); // Login bem-sucedido
            }
            else
            {
                return Unauthorized(new { message = "Usuário ou senha incorretos" }); // Login falhou
            }
        }

        // Endpoint para adicionar novo usuário
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Usuario usuario)
            
        {
            var result = _login.AddLogin(usuario);
            if (result)  // Tenta adicionar o novo usuário
            {
                return Ok(new { message = "Usuário registrado com sucesso!" });  // Sucesso na criação
            }
            else
            {
                return BadRequest(new { message = "Erro ao registrar o usuário!" });  // Falha na criação
            }
        }
    }
}
