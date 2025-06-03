using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace Repositories.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FUNewsDbContext _context;

        public CategoryRepository(FUNewsDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            var canDelete = !await _context.NewsArticles.AnyAsync(a => a.CategoryID == category.ID);
            if (!canDelete)
                throw new InvalidOperationException("Không thể xóa category vì đang được sử dụng trong bài viết.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.ChildCategories)
                .Include(c => c.NewsArticles)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.ChildCategories)
                .Include(c => c.NewsArticles)
                .FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsNameExistsAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CanDeleteCategory(int categoryId)
        {
            return !await _context.NewsArticles.AnyAsync(a => a.CategoryID == categoryId);
        }
    }

}
