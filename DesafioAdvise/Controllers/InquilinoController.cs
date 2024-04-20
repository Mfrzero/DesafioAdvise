using Imobiliaria.Api.Models;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquilinoController : ControllerBase
    {
        private readonly IInquilinoService _service;
        private readonly ILogger<InquilinoController> _logger;

        public InquilinoController(IInquilinoService service, ILogger<InquilinoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquilino>>> GetAllInquilinos()
        {
            try
            {
                var inquilinos = await _service.GetAllInquilinos();
                return Ok(inquilinos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar Inquilinos");
                return StatusCode(500, "Erro ao retornar Inquilinos");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inquilino>> GetInquilinoById(int id)
        {
            try
            {
                var inquilino = await _service.GetInquilinoById(id);
                if (inquilino == null)
                {
                    return NotFound(new { mensagem = "Inquilino não encontrado." });
                }
                return Ok(inquilino);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar Inquilino por ID");
                return StatusCode(500, "Erro ao retornar Inquilino por ID");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddInquilino(Inquilino inquilino)
        {
            try
            {
                await _service.AddInquilino(inquilino);
                return CreatedAtAction(nameof(GetInquilinoById), new { id = inquilino.Id }, inquilino);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar Inquilino");
                return StatusCode(500, "Erro ao adicionar Inquilino");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInquilino(int id, Inquilino inquilino)
        {
            try
            {
                if (id != inquilino.Id)
                {
                    return BadRequest(new { mensagem = "Inquilino não encontrado." });
                }
                await _service.UpdateInquilino(inquilino);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Inquilino");
                return StatusCode(500, "Erro ao atualizar Inquilino");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInquilino(int id)
        {
            try
            {
                await _service.DeleteInquilino(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Inquilino");
                return StatusCode(500, "Erro ao deletar Inquilino");
            }
        }
    }

}
