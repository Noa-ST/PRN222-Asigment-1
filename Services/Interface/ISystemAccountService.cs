using BusinessObjects.DTOs;

namespace Services.Interface
{
    public interface ISystemAccountService
    {
        Task<IEnumerable<GetSystemAccountDto>> GetAllAsync();
        Task<GetSystemAccountDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSystemAccountDto dto);
        Task UpdateAsync(UpdateSystemAccountDto dto);
        Task DeleteAsync(int id);
    }
}
