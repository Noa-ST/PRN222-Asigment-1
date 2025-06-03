
using BusinessObjects.DTOs;

namespace Repositories.Interface
{
    public interface INewsArticleRepository
    {
        Task<IEnumerable<GetNewsArticleDto>> GetAllAsync();
        Task<GetNewsArticleDto> GetByIdAsync(int id);
        Task CreateAsync(CreateNewsArticleDto dto);
        Task UpdateAsync(UpdateNewsArticleDto dto);
        Task DeleteAsync(int id);
    }
}
