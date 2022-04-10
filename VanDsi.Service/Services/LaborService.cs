using AutoMapper;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Repositories;
using VanDsi.Core.Services;
using VanDsi.Core.UnitOfWorks;

namespace VanDsi.Service.Services
{
    public class LaborService : Service<Labor>, ILaborService
    {
        private readonly ILaborRepository _laborRepository;
        private readonly IMapper _mapper;

        public LaborService(IUnitOfWork unitOfWork, IGenericRepository<Labor> repository, ILaborRepository laborRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _laborRepository = laborRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<LaborDto>>> GetLaborsForEmployeeId(int employeId)
        {
            var laborList = await _laborRepository.GetLaborsForEmployeeId(employeId);
            var laborDto = _mapper.Map<List<LaborDto>>(laborList);
            return CustomResponseDto<List<LaborDto>>.Success(200, laborDto);
        }

    }
}
