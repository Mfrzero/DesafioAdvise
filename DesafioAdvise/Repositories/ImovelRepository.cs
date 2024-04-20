using Imobiliaria.Api.Data;
using Imobiliaria.Api.Models;
using Imobiliaria.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria.Api.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly ImobiliariaContext _context;

        public ImovelRepository(ImobiliariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Imovel>> GetAll()
        {
            return await _context.Imoveis.ToListAsync();
        }

        public async Task<Imovel> GetById(int id)
        {
            return await _context.Imoveis.FindAsync(id);
        }

        public async Task Add(Imovel imovel)
        {
            await _context.Imoveis.AddAsync(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Imovel imovel)
        {
            _context.Imoveis.Update(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
