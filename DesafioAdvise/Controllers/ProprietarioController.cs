using Imobiliaria.Api.Models;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioService _service;
        private readonly ILogger<ProprietarioController> _logger;

        public ProprietarioController(IProprietarioService service, ILogger<ProprietarioController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proprietario>>> GetAllProprietarios()
        {
            try
            {
                var proprietarios = await _service.GetAllProprietarios();
                return Ok(proprietarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar Proprietário");
                return StatusCode(500, "Erro ao retornar Proprietário");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietario>> GetProprietarioById(int id)
        {
            try
            {
                var proprietario = await _service.GetProprietarioById(id);

                if (proprietario == null)
                {
                    return NotFound(new { mensagem = "Propietário não encontrado." });
                }
                return Ok(proprietario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar Proprietário por ID");
                return StatusCode(500, "Erro ao retornar Proprietário por ID");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProprietario(Proprietario proprietario)
        {
            try
            {
                await _service.AddProprietario(proprietario);
                return CreatedAtAction(nameof(GetProprietarioById), new { id = proprietario.Id }, proprietario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar Proprietário");
                return StatusCode(500, "Erro ao criar Proprietário");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProprietario(int id, Proprietario proprietario)
        {
            try
            {
                if (id != proprietario.Id)
                {
                    return BadRequest(new { mensagem = "Proprietário não encontrado." });
                }
                await _service.UpdateProprietario(proprietario);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Proprietário");
                return StatusCode(500, "Erro ao atualizar Proprietário");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProprietario(int id)
        {
            try
            {
                await _service.DeleteProprietario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Proprietário");
                return StatusCode(500, "Erro ao deletar Proprietário");
            }

        }
    }

}
