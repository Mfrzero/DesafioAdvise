using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Services.Interfaces
{
    public interface IImovelService
    {
        Task<IEnumerable<Imovel>> GetAllImoveis();
        Task<Imovel> GetImovelById(int id);
        Task AddImovel(Imovel imovel);
        Task UpdateImovel(Imovel imovel);
        Task DeleteImovel(int id);
    }
}
