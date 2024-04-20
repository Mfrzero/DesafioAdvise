using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Services.Interfaces
{
    public interface ICorretorService
    {
        Task<IEnumerable<Corretor>> GetAllCorretores();
        Task<Corretor> GetCorretorById(int id);
        Task AddCorretor(Corretor corretor);
        Task UpdateCorretor(Corretor corretor);
        Task DeleteCorretor(int id);
    }
}
