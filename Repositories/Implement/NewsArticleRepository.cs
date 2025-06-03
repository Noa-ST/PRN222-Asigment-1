using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly FUNewsDbContext _context;
        public NewsArticleRepository(FUNewsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetNewsArticleDto>> GetAllAsync()
        {
            return await _context.NewsArticles
                .Include(n => n.Category)
                .Include(n => n.CreatedBy)
                .Include(n => n.UpdatedBy)
                .Include(n => n.NewsTaqs).ThenInclude(nt => nt.Taq)
                .Select(n => new GetNewsArticleDto
                {
                    ID = n.ID,
                    Title = n.Title,
                    Content = n.Content,
                    CreatedDate = n.CreatedDate,
                    UpdatedDate = n.UpdatedDate,
                    CreatedByName = n.CreatedBy.FullName,
                    UpdatedByName = n.UpdatedBy != null ? n.UpdatedBy.FullName : null,
                    CategoryName = n.Category.Name,
                    NewsStatus = n.NewsStatus,
                    CategoryID = n.CategoryID,
                    Taqs = n.NewsTaqs.Select(nt => new GetTaqDto { ID = nt.Taq.ID, Name = nt.Taq.Name }).ToList()
                }).ToListAsync();
        }

        public async Task<GetNewsArticleDto> GetByIdAsync(int id)
        {
            return await GetAllAsync().ContinueWith(t => t.Result.FirstOrDefault(n => n.ID == id));
        }

        public async Task CreateAsync(CreateNewsArticleDto dto)
        {
            var entity = new NewsArticle
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedByID = dto.CreatedByID,
                CategoryID = dto.CategoryID,
                NewsStatus = dto.NewsStatus,
                CreatedDate = DateTime.Now,
                NewsTaqs = dto.TaqIDs.Select(tid => new NewsTaq { TaqID = tid }).ToList()
            };

            _context.NewsArticles.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateNewsArticleDto dto)
        {
            var entity = await _context.NewsArticles
                .Include(n => n.NewsTaqs)
                .FirstOrDefaultAsync(n => n.ID == dto.ID);

            if (entity == null) return;

            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.CategoryID = dto.CategoryID;
            entity.NewsStatus = dto.NewsStatus;
            entity.UpdatedByID = dto.UpdatedByID;
            entity.UpdatedDate = DateTime.Now;

            entity.NewsTaqs.Clear();
            entity.NewsTaqs = dto.TaqIDs.Select(tid => new NewsTaq { NewsArticleID = dto.ID, TaqID = tid }).ToList();

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.NewsArticles.FindAsync(id);
            if (entity != null)
            {
                _context.NewsArticles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
