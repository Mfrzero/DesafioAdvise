using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Repositories.Interfaces
{
    public interface IInquilinoRepository
    {
        Task<IEnumerable<Inquilino>> GetAll();
        Task<Inquilino> GetById(int id);
        Task Add(Inquilino inquilino);
        Task Update(Inquilino inquilino);
        Task Delete(int id);
    }
}
