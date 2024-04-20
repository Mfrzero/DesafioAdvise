using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Imobiliaria.Api.Services.Interfaces;

namespace Imobiliaria.Api.Services
{
    public class CorretorService : ICorretorService
    {
        private readonly ICorretorRepository _repository;
        private readonly ILogger<CorretorService> _logger;

        public CorretorService(ICorretorRepository repository, ILogger<CorretorService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Corretor>> GetAllCorretores()
        {
            try
            {
                _logger.LogInformation("Retornando todos os Corretores");

                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Corretores");
                throw;
            }
        }

        public async Task<Corretor> GetCorretorById(int id)
        {
            try
            {
                _logger.LogInformation("Corretor retornado por id: {@id}", id);

                return await _repository.GetById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Corretor");
                throw;
            }
        }

        public async Task AddCorretor(Corretor corretor)
        {
            try
            {

                await _repository.Add(corretor);
                _logger.LogInformation("Corretor adicionado: {@corretor}", new { corretor.Id, corretor.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar Corretor");
                throw;
            }
        }

        public async Task UpdateCorretor(Corretor corretor)
        {
            try
            {
                await _repository.Update(corretor);
                _logger.LogInformation("Corretor atualizado: {@corretor}", new { corretor.Id, corretor.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Corretor");
                throw;
            }
        }

        public async Task DeleteCorretor(int id)
        {
            try
            {
                await _repository.Delete(id);
                _logger.LogInformation("Corretor deletado : {@id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Corretor");
                throw;
            }
        }
    }
}
