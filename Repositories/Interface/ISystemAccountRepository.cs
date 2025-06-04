using BusinessObjects.Entities;

namespace Repositories.Interface
{
    public interface ISystemAccountRepository
    {
        SystemAccount GetByEmail(string email);
        Task<IEnumerable<SystemAccount>> GetAllAsync();
        Task<SystemAccount> GetByIdAsync(int id);
        Task AddAsync(SystemAccount account);
        Task UpdateAsync(SystemAccount account);
        Task DeleteAsync(int id);
    }
}
