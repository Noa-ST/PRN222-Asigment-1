using BusinessObjects.DTOs;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
namespace Repositories.Implement
{
    public class AdminReportRepository : IAdminReportRepository
    {
        private readonly FUNewsDbContext _context;

        public AdminReportRepository(FUNewsDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalArticlesAsync()
        {
            return await _context.NewsArticles.CountAsync();
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.SystemAccounts.CountAsync();
        }

        public async Task<List<CategoryReportDto>> GetArticleCountByCategoryAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryReportDto
                {
                    CategoryName = c.Name,
                    ArticleCount = c.NewsArticles.Count()
                })
                .ToListAsync();
        }
    }
}
