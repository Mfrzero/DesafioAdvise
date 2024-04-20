using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Repositories.Interfaces
{
    public interface IProprietarioRepository
    {
        Task<IEnumerable<Proprietario>> GetAll();
        Task<Proprietario> GetById(int id);
        Task Add(Proprietario proprietario);
        Task Update(Proprietario proprietario);
        Task Delete(int id);
    }
}
