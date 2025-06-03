using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class TaqRepository : ITaqRepository
    {
        private readonly FUNewsDbContext _context;

        public TaqRepository(FUNewsDbContext context)
        {
            _context = context;
        }

        public async Task<Taq> CreateAsync(Taq taq)
        {
            _context.Taqs.Add(taq);
            await _context.SaveChangesAsync();
            return taq;
        }

        public async Task DeleteAsync(Taq taq)
        {
            _context.Taqs.Remove(taq);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Taq>> GetAllAsync()
        {
            return await _context.Taqs.ToListAsync();
        }

        public async Task<Taq?> GetByIdAsync(int id)
        {
            return await _context.Taqs.FindAsync(id);
        }

        public async Task UpdateAsync(Taq taq)
        {
            _context.Taqs.Update(taq);
            await _context.SaveChangesAsync();
        }
    }
}
