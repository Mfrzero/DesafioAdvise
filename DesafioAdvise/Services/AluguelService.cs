using Imobiliaria.Api.Data;
using Imobiliaria.Api.Models;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

//Nesta pasta estão os serviços da aplicação, que encapsulam a lógica de negócios e coordenam a interação entre os controladores, os repositórios e os modelos.
namespace Imobiliaria.Api.Services
{
    //Sua única responsabilidade é lidar com as operações relacionadas ao aluguel de imóveis, como verificar a disponibilidade do imóvel,
    //criar contratos de aluguel e listar imóveis alugados.
    public class AluguelService : IAluguelService
    {
        private readonly ImobiliariaContext _context;
        private readonly ILogger<AluguelService> _logger;

        //Dependency Inversion Principle: seguindo o princípio de DIP.
        //Isso permite que diferentes implementações do contexto do banco de dados ou do logger sejam usadas sem alterar o código da classe.
        public AluguelService(ImobiliariaContext context, ILogger<AluguelService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AlugarImovel(int idInquilino, int idImovel, int idCorretor, int idProprietario)
        {
            try
            {
                // Verifica se inquilino, imóvel, corretor e proprietário existem no banco de dados
                var imovel = await _context.Imoveis.FindAsync(idImovel);
                if (imovel == null)
                {
                    //Os erros são registrados usando o logger
                    _logger.LogError("Imóvel não encontrado.");
                    return false;
                }
                if (imovel.Alugado)
                {
                    _logger.LogError("Imóvel já está alugado.");
                    return false;
                }
                var inquilino = await _context.Inquilinos.FindAsync(idInquilino);
                if (inquilino == null)
                {
                    _logger.LogError("Inquilino não encontrado.");
                    return false;
                }
                var corretor = await _context.Corretores.FindAsync(idCorretor);
                if (corretor == null)
                {
                    _logger.LogError("Corretor não encontrado.");
                    return false;
                }
                var proprietario = await _context.Proprietarios.FindAsync(idProprietario);
                if (proprietario == null)
                {
                    _logger.LogError("Proprietário não encontrado.");
                    return false;
                }

                var contrato = new ContratoAluguel
                {
                    Inquilino = inquilino,
                    Imovel = imovel,
                    Corretor = corretor,
                    Proprietario = proprietario,
                    DataInicio = DateTime.Today,
                    DataFim = DateTime.Now.AddMonths(12)
                };

                imovel.Alugado = true;

                _context.ContratoAlugueis.Add(contrato);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Imóvel alugado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao alugar imóvel: {ex.Message}");
                return false;
            }
        }
        //É usado um DTO para transportar os dados necessários, o que é uma prática comum para evitar a exposição de detalhes
        //de implementação e reduzir a quantidade de dados transferidos pela rede.
        public async Task<List<ImovelAlugadoDTO>> ListarImoveisAlugados()
        {
            try
            {
                var imoveisAlugados = await _context.ContratoAlugueis
                    .Where(a => a.DataInicio <= DateTime.Now && a.DataFim >= DateTime.Now)
                    .Include(a => a.Imovel)
                    .Include(a => a.Proprietario)
                    .Include(a => a.Corretor)
                    .Include(a => a.Inquilino)
                    .Select(a => new ImovelAlugadoDTO
                    {
                        ImovelId = a.Imovel.Id,
                        Endereco = a.Imovel.Endereco,
                        ProprietarioNome = a.Proprietario.Nome,
                        CorretorNome = a.Corretor.Nome,
                        InquilinoNome = a.Inquilino.Nome
                    })
                    .ToListAsync();

                return imoveisAlugados;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar imóveis alugados: {ex.Message}");
                return null;
            }
        }
    }
}