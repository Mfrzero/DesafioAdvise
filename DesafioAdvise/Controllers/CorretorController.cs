using Imobiliaria.Api.Models;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Api.Controllers
{
    //Mantem uma única responsabilidade, que é lidar com solicitações HTTP relacionadas aos corretores. 
    [ApiController]
    [Route("api/[controller]")]
    public class CorretorController : ControllerBase
    {
        private readonly ICorretorService _service;
        private readonly ILogger<CorretorController> _logger;

        public CorretorController(ICorretorService service, ILogger<CorretorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        //Segue as convenções de nomenclatura de endpoints RESTful
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Corretor>>> GetAllCorretores()
        {
            try
            {
                var corretores = await _service.GetAllCorretores();
                return Ok(corretores);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar corretores");
                return StatusCode(500, "Erro ao retornar corretores");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Corretor>> GetCorretorById(int id)
        {
            try
            {
                var corretor = await _service.GetCorretorById(id);
                if (corretor == null)
                {
                    return NotFound(new { mensagem = "Corretor não encontrado." });
                }
                return Ok(corretor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar corretor por ID");
                return StatusCode(500, "Erro ao retornar corretor por ID");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCorretor(Corretor corretor)
        {
            try
            {
                await _service.AddCorretor(corretor);
                return CreatedAtAction(nameof(GetCorretorById), new { id = corretor.Id }, corretor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar corretor");
                return StatusCode(500, "Erro ao adicionar corretor");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCorretor(int id, Corretor corretor)
        {
            try
            {
                if (id != corretor.Id)
                {
                    return BadRequest(new { mensagem = "Corretor não encontrado." });
                }
                await _service.UpdateCorretor(corretor);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar corretor");
                return StatusCode(500, "Erro ao atualizar corretor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCorretor(int id)
        {
            try
            {
                await _service.DeleteCorretor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar corretor");
                return StatusCode(500, "Erro ao deletar corretor");
            }
        }
    }
}
