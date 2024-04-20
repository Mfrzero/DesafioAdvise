using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Services.Interfaces
{
    public interface IProprietarioService
    {
        Task<IEnumerable<Proprietario>> GetAllProprietarios();
        Task<Proprietario> GetProprietarioById(int id);
        Task AddProprietario(Proprietario proprietario);
        Task UpdateProprietario(Proprietario proprietario);
        Task DeleteProprietario(int id);
    }
}
