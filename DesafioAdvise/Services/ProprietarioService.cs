using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Imobiliaria.Api.Services.Interfaces;

namespace Imobiliaria.Api.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _repository;
        private readonly ILogger<ProprietarioService> _logger;

        public ProprietarioService(IProprietarioRepository repository, ILogger<ProprietarioService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Proprietario>> GetAllProprietarios()
        {
            try
            {
                _logger.LogInformation("Retornando todos os Proprietários");

                return await _repository.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Proprietário");
                throw;
            }
        }

        public async Task<Proprietario> GetProprietarioById(int id)
        {
            try
            {
                _logger.LogInformation("Proprietário retornado por id: {@id}", id);

                return await _repository.GetById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao pegar Proprietário");
                throw;
            }
        }

        public async Task AddProprietario(Proprietario proprietario)
        {
            try
            {

                await _repository.Add(proprietario);
                _logger.LogInformation("Proprietário adicionado: {@proprietario}", new { proprietario.Id, proprietario.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar Proprietário");
                throw;
            }
        }

        public async Task UpdateProprietario(Proprietario proprietario)
        {
            try
            {
                await _repository.Update(proprietario);
                _logger.LogInformation("Proprietário atualizado: {@propietario}", new { proprietario.Id, proprietario.Nome });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar Proprietário");
                throw;
            }
        }

        public async Task DeleteProprietario(int id)
        {
            try
            {
                await _repository.Delete(id);
                _logger.LogInformation("Proprietário deletado : {@id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar Proprietário");
                throw;
            }
        }
    }
}
