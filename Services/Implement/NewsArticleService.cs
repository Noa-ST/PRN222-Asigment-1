using BusinessObjects.DTOs;
using Repositories.Interface;
namespace Services.Implement
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly INewsArticleRepository _repo;

        public NewsArticleService(INewsArticleRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<GetNewsArticleDto>> GetAllAsync() => _repo.GetAllAsync();

        public Task<GetNewsArticleDto> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task CreateAsync(CreateNewsArticleDto dto) => _repo.CreateAsync(dto);

        public Task UpdateAsync(UpdateNewsArticleDto dto) => _repo.UpdateAsync(dto);

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
