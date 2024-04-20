using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Imobiliaria.Api.Services.Interfaces;

namespace Imobiliaria.Api.Services
{
    public class InquilinoService : IInquilinoService
    {
        private readonly IInquilinoRepository _repository;
        private readonly ILogger<InquilinoService> _logger;

        public InquilinoService(IInquilinoRepository repository, ILogger<InquilinoService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Inquilino>> GetAllInquilinos()
        {
            try
            {
                _logger.LogInformation("Retornando todos os Inquilinos");

                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Inquilinos");
                throw;
            }

        }

        public async Task<Inquilino> GetInquilinoById(int id)
        {
            try
            {
                _logger.LogInformation("Inquilino retornado por id: {@id}", id);

                return await _repository.GetById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Inquilino");
                throw;
            }

        }

        public async Task AddInquilino(Inquilino inquilino)
        {
            try
            {

                await _repository.Add(inquilino);
                _logger.LogInformation("Inquilino adicionado: {@inquilino}", new { inquilino.Id, inquilino.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar Inquilino");
                throw;
            }
        }

        public async Task UpdateInquilino(Inquilino inquilino)
        {
            try
            {
                await _repository.Update(inquilino);
                _logger.LogInformation("Inquilino atualizado: {@inquilino}", new { inquilino.Id, inquilino.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Inquilino");
                throw;
            }
        }

        public async Task DeleteInquilino(int id)
        {
            try
            {
                await _repository.Delete(id);
                _logger.LogInformation("Inquilino deletado : {@id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Inquilino");
                throw;
            }
        }
    }
}
