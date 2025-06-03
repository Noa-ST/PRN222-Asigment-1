using BusinessObjects.DTOs;

namespace Repositories.Interface
{
    public interface IAdminReportRepository
    {
        Task<int> GetTotalArticlesAsync();
        Task<int> GetTotalUsersAsync();
        Task<List<CategoryReportDto>> GetArticleCountByCategoryAsync();
    }
}
