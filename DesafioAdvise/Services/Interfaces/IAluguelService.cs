using Imobiliaria.Api.Models;

namespace Imobiliaria.Api.Services.Interfaces
{
    public interface IAluguelService
    {
        Task<bool> AlugarImovel(int imovelId, int proprietarioId, int corretorId, int inquilinoId);
        Task<List<ImovelAlugadoDTO>> ListarImoveisAlugados();
    }
}
