using Imobiliaria.Api.Models;

//Essas são as interfaces de repositórios, que são os contratos que os repositorios devem seguir.
namespace Imobiliaria.Api.Repositories.Interfaces
{
    //Sua única responsabilidade é definir métodos para operações CRUD relacionadas à entidade Corretor.
    //Cada método tem uma única responsabilidade clara.
    public interface ICorretorRepository
    {
        Task<IEnumerable<Corretor>> GetAll();
        Task<Corretor> GetById(int id);
        Task Add(Corretor corretor);
        Task Update(Corretor corretor);
        Task Delete(int id);
    }
}
