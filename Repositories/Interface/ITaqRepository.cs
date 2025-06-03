using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ITaqRepository
    {
        Task<IEnumerable<Taq>> GetAllAsync();
        Task<Taq?> GetByIdAsync(int id);
        Task<Taq> CreateAsync(Taq taq);
        Task UpdateAsync(Taq taq);
        Task DeleteAsync(Taq taq);
    }
}
