using Imobiliaria.Api.Data;
using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Api.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly ImobiliariaContext _context;

        public ProprietarioRepository(ImobiliariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proprietario>> GetAll()
        {
            return await _context.Proprietarios.ToListAsync();
        }

        public async Task<Proprietario> GetById(int id)
        {
            return await _context.Proprietarios.FindAsync(id);
        }

        public async Task Add(Proprietario proprietario)
        {
            await _context.Proprietarios.AddAsync(proprietario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Proprietario proprietario)
        {
            _context.Proprietarios.Update(proprietario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var proprietario = await _context.Proprietarios.FindAsync(id);
            if (proprietario != null)
            {
                _context.Proprietarios.Remove(proprietario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
