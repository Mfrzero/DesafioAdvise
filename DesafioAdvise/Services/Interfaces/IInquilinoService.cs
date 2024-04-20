using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Services.Interfaces
{
    public interface IInquilinoService
    {
        Task<IEnumerable<Inquilino>> GetAllInquilinos();
        Task<Inquilino> GetInquilinoById(int id);
        Task AddInquilino(Inquilino inquilino);
        Task UpdateInquilino(Inquilino inquilino);
        Task DeleteInquilino(int id);
    }
}
