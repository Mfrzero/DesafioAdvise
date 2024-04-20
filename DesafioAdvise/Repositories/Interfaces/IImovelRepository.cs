using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Repositories.Interfaces
{
    public interface IImovelRepository
    {
        Task<IEnumerable<Imovel>> GetAll();
        Task<Imovel> GetById(int id);
        Task Add(Imovel imovel);
        Task Update(Imovel imovel);
        Task Delete(int id);
    }
}
