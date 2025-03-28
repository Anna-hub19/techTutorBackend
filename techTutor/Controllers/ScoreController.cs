using Microsoft.AspNetCore.Mvc;
using techTutor.Domain.Entity;
using techTutor.Domain.Interfaces;

namespace techTutor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : Controller
    {
        private readonly IScore _score;

        public ScoreController(IScore score)
        {
            _score = score;
        }

        // Endpoint para adicionar pontos ao usuário
        [HttpPost("add")]
        public IActionResult AddScore([FromBody] Usuario usuario)
        {
            if (_score.AddScore(usuario))  // Adiciona os pontos ao usuário
            {
                return Ok(new { message = "Pontos adicionados com sucesso!" });
            }
            else
            {
                return BadRequest(new { message = "Erro ao adicionar pontos!" });
            }
        }

        // Endpoint para pegar o score do usuário
        [HttpGet("{userName}")]
        public IActionResult GetScore(string userName)
        {
            var usuario = new Usuario { UserName = userName };

            var score = _score.GetScore(usuario);
            if (score != null)
            {
                return Ok(new { score = score.Score });
            }
            else
            {
                return NotFound(new { message = "Usuário não encontrado!" });
            }
        }
    }
}
