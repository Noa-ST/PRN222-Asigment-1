using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class AdminReportService : IAdminReportService
    {
        private readonly IAdminReportRepository _adminReportRepository;

        public AdminReportService(IAdminReportRepository adminReportRepository)
        {
            _adminReportRepository = adminReportRepository;
        }

        public async Task<AdminReportDto> GetAdminReportAsync()
        {
            return new AdminReportDto
            {
                TotalArticles = await _adminReportRepository.GetTotalArticlesAsync(),
                TotalUsers = await _adminReportRepository.GetTotalUsersAsync(),
                ArticlesByCategory = await _adminReportRepository.GetArticleCountByCategoryAsync()
            };
        }

    }
}
