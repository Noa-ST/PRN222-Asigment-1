using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _repo;
        private readonly IMapper _mapper;

        public SystemAccountService(ISystemAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetSystemAccountDto>> GetAllAsync()
        {
            var accounts = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<GetSystemAccountDto>>(accounts);
        }

        public async Task<GetSystemAccountDto> GetByIdAsync(int id)
        {
            var account = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetSystemAccountDto>(account);
        }

        public async Task CreateAsync(CreateSystemAccountDto dto)
        {
            var account = _mapper.Map<SystemAccount>(dto);
            await _repo.AddAsync(account);
        }

        public async Task UpdateAsync(UpdateSystemAccountDto dto)
        {
            var account = _mapper.Map<SystemAccount>(dto);
            await _repo.UpdateAsync(account);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }

}
