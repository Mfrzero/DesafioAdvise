using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Imobiliaria.Api.Services.Interfaces;

namespace Imobiliaria.Api.Services
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _repository;
        private readonly ILogger<ImovelService> _logger;

        public ImovelService(IImovelRepository repository, ILogger<ImovelService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Imovel>> GetAllImoveis()
        {
            try
            {
                _logger.LogInformation("Retornando todos os Imóveis");

                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Imóveis");
                throw;
            }
        }

        public async Task<Imovel> GetImovelById(int id)
        {
            try
            {
                _logger.LogInformation("Imóvel retornado por id: {@id}", id);

                return await _repository.GetById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Imóvel");
                throw;
            }
        }

        public async Task AddImovel(Imovel imovel)
        {
            try
            {

                await _repository.Add(imovel);
                _logger.LogInformation("Imóvel adicionado: {@imovel}", new { imovel.Id, imovel.Endereco });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar Imóvel");
                throw;
            }
        }

        public async Task UpdateImovel(Imovel imovel)
        {
            try
            {
                await _repository.Update(imovel);
                _logger.LogInformation("Imóvel atualizado: {@imovel}", new { imovel.Id, imovel.Endereco });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Imóvel");
                throw;
            }
        }

        public async Task DeleteImovel(int id)
        {
            try
            {
                await _repository.Delete(id);
                _logger.LogInformation("Imóvel deletado : {@id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Imóvel");
                throw;
            }
        }
    }
}
