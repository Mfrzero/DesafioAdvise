using Imobiliaria.Api.Data;
using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

//Essas são as classes de repositórios, que são responsáveis por abstrair as operações de acesso ao banco de dados
namespace Imobiliaria.Api.Repositories
{
    //Sua única responsabilidade é lidar com a persistência dos objetos Corretor no banco de dados.
    //E implementa o padrão Repository
    public class CorretorRepository : ICorretorRepository
    {
        private readonly ImobiliariaContext _context;

        public CorretorRepository(ImobiliariaContext context)
        {
            _context = context;
        }

        //As assinaturas dos métodos são simples e diretas
        public async Task<IEnumerable<Corretor>> GetAll()
        {
            return await _context.Corretores.ToListAsync();
        }

        public async Task<Corretor> GetById(int id)
        {
            return await _context.Corretores.FindAsync(id);
        }

        public async Task Add(Corretor corretor)
        {
            await _context.Corretores.AddAsync(corretor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Corretor corretor)
        {
            _context.Corretores.Update(corretor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var corretor = await _context.Corretores.FindAsync(id);
            if (corretor != null)
            {
                _context.Corretores.Remove(corretor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
