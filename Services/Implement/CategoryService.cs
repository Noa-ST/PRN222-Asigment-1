using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Services.Interface;

namespace Services.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly FUNewsDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(FUNewsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories
                .Include(c => c.NewsArticles)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.NewsArticles)
                .FirstOrDefaultAsync(c => c.ID == id);

            return category == null ? null : _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _context.Categories.FindAsync(dto.ID);
            if (category == null) return null;

            _mapper.Map(dto, category);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories
                .Include(c => c.NewsArticles)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (category == null || category.NewsArticles.Any())
                return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
