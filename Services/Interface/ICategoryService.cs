using BusinessObjects.DTOs;

namespace Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
