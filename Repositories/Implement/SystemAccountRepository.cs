using BusinessObjects.Entities;
using DataAccessObjects;
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
    }
}
