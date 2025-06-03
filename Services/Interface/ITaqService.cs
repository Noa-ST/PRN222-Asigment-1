using BusinessObjects.DTOs;

namespace Services.Interface
{
    public interface ITaqService
    {
        Task<IEnumerable<GetTaqDto>> GetAllAsync();
        Task<GetTaqDto?> GetByIdAsync(int id);
        Task<GetTaqDto> CreateAsync(CreateTaqDto dto);
        Task<GetTaqDto?> UpdateAsync(UpdateTaqDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
