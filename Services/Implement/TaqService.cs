using AutoMapper;
using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement
{
    public class TaqService : ITaqService
    {
        private readonly ITaqRepository _taqRepository;
        private readonly IMapper _mapper;

        public TaqService(ITaqRepository taqRepository, IMapper mapper)
        {
            _taqRepository = taqRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTaqDto>> GetAllAsync()
        {
            var taqs = await _taqRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTaqDto>>(taqs);
        }

        public async Task<GetTaqDto?> GetByIdAsync(int id)
        {
            var taq = await _taqRepository.GetByIdAsync(id);
            return taq == null ? null : _mapper.Map<GetTaqDto>(taq);
        }

        public async Task<GetTaqDto> CreateAsync(CreateTaqDto dto)
        {
            var taq = _mapper.Map<Taq>(dto);
            taq = await _taqRepository.CreateAsync(taq);
            return _mapper.Map<GetTaqDto>(taq);
        }

        public async Task<GetTaqDto?> UpdateAsync(UpdateTaqDto dto)
        {
            var taq = await _taqRepository.GetByIdAsync(dto.ID);
            if (taq == null) return null;

            _mapper.Map(dto, taq);
            await _taqRepository.UpdateAsync(taq);
            return _mapper.Map<GetTaqDto>(taq);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taq = await _taqRepository.GetByIdAsync(id);
            if (taq == null) return false;

            await _taqRepository.DeleteAsync(taq);
            return true;
        }
    }
}
