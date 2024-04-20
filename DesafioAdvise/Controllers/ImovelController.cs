using Imobiliaria.Api.Models;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelService _service;
        private readonly ILogger<ImovelController> _logger;

        public ImovelController(IImovelService service, ILogger<ImovelController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetAllImoveis()
        {
            try
            {
                var imoveis = await _service.GetAllImoveis();
                return Ok(imoveis);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar imóveis");
                return StatusCode(500, "Erro ao retornar imóveis");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Imovel>> GetImovelById(int id)
        {
            try
            {
                var imovel = await _service.GetImovelById(id);
                if (imovel == null)
                {
                    return NotFound(new { mensagem = "Imóvel não encontrado." });
                }
                return Ok(imovel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao retornar imóvel por ID");
                return StatusCode(500, "Erro ao retornar imóvel por ID");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddImovel(Imovel imovel)
        {
            try
            {
                await _service.AddImovel(imovel);
                return CreatedAtAction(nameof(GetImovelById), new { id = imovel.Id }, imovel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar imóvel");
                return StatusCode(500, "Erro ao adicionar imóvel");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateImovel(int id, Imovel imovel)
        {
            try
            {
                if (id != imovel.Id)
                {
                    return BadRequest(new { mensagem = "Imóvel não encontrado." });
                }
                await _service.UpdateImovel(imovel);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar imóvel");
                return StatusCode(500, "Erro ao atualizar imóvel");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImovel(int id)
        {
            try
            {
                await _service.DeleteImovel(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar imóvel");
                return StatusCode(500, "Erro ao deletar imóvel");
            }
        }
    }
}
