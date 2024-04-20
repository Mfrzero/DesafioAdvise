using Imobiliaria.Api.Data;
using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Api.Repositories
{
    public class InquilinoRepository : IInquilinoRepository
    {
        private readonly ImobiliariaContext _context;

        public InquilinoRepository(ImobiliariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inquilino>> GetAll()
        {
            return await _context.Inquilinos.ToListAsync();
        }

        public async Task<Inquilino> GetById(int id)
        {
            return await _context.Inquilinos.FindAsync(id);
        }

        public async Task Add(Inquilino inquilino)
        {
            await _context.Inquilinos.AddAsync(inquilino);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Inquilino inquilino)
        {
            _context.Inquilinos.Update(inquilino);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var inquilino = await _context.Inquilinos.FindAsync(id);
            if (inquilino != null)
            {
                _context.Inquilinos.Remove(inquilino);
                await _context.SaveChangesAsync();
            }
        }
    }
}
