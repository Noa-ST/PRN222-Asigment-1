using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;


namespace Repositories.Implement
{
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly FUNewsDbContext _context;

        public SystemAccountRepository(FUNewsDbContext context)
        {
            _context = context;
        }

        public SystemAccount GetByEmail(string email)
        {
            return _context.SystemAccounts.FirstOrDefault(x => x.Email == email);
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAsync() =>
        await _context.SystemAccounts.ToListAsync();

        public async Task<SystemAccount> GetByIdAsync(int id) =>
            await _context.SystemAccounts.FindAsync(id);

        public async Task AddAsync(SystemAccount account)
        {
            await _context.SystemAccounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemAccount account)
        {
            _context.SystemAccounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _context.SystemAccounts.FindAsync(id);
            if (account != null)
            {
                _context.SystemAccounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
