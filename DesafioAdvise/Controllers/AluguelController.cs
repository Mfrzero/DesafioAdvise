using Imobiliaria.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

//Essas classes contém os controladores da API, que são responsáveis por receber as requisições HTTP, chamar os serviços correspondentes e retornar as respostas adequadas para o cliente
namespace Imobiliaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly IAluguelService _aluguelService;
        private readonly ILogger<CorretorController> _logger;

        //Utiliza injeção de dependência para fornecer uma instância de IAluguelService e ILogger. Isso facilita a manutenção e teste do código.
        public AluguelController(IAluguelService aluguelService, ILogger<CorretorController> logger)
        {
            _aluguelService = aluguelService;
            _logger = logger;
        }

        //Os nomes de métodos e variáveis são descritivos, o que facilita a compreensão do que cada método faz.
        [HttpGet("imoveis-alugados")]
        public async Task<IActionResult> ListarImoveisAlugados()
        {
            try
            {
                var imoveisAlugados = await _aluguelService.ListarImoveisAlugados();

                //O código trata adequadamente os casos de sucesso e falha, retornando os códigos de status HTTP apropriados e mensagens de erro significativas.
                if (imoveisAlugados == null)
                {
                    return NotFound("Não há imóveis alugados no momento.");
                }

                return Ok(imoveisAlugados);
            }
            catch (Exception ex)
            {
                //Registra os erros usando o logger, o que é uma boa prática.
                _logger.LogError(ex, "Erro ao Listar Imoveis Alugados");
                return StatusCode(500, "Erro ao Listar Imoveis Alugados");
            }
        }

        //Os métodos são relativamente curtos e focados em uma única responsabilidade, facilitando a compreensão e manutenção do código.
        [HttpPost]
        public async Task<IActionResult> AlugarImovelParaInquilino(int idInquilino, int idImovel, int idCorretor, int idProprietario)
        {
            try
            {
                var sucesso = await _aluguelService.AlugarImovel(idInquilino, idImovel, idCorretor, idProprietario);

                if (sucesso)
                {
                    return Ok("Imóvel alugado com sucesso!");
                }
                else
                {
                    return BadRequest("Não foi possível alugar o imóvel.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao Alugar Imóvel");
                return StatusCode(500, "Erro ao Alugar Imóvel");
            }
        }
    }
}
