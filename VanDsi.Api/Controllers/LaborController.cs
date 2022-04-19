using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Api.Filters;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    [Authorize]
    public class LaborController : CustomBaseController
    {
        private readonly ILaborService _laborService;
        private readonly IMapper _mapper;

        public LaborController(ILaborService laborService, IMapper mapper)
        {
            _laborService = laborService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var labor = await _laborService.GetByIdAsync(id);
            var laborDto = _mapper.Map<LaborDto>(labor);
            return CreateActionResult(CustomResponseDto<LaborDto>.Success(200,laborDto));
        }

        [HttpGet("[action]/{employeeId:int}")]
        public async Task<IActionResult> GetLaborsForEmployeeId(int employeeId)
        {
            return CreateActionResult(await _laborService.GetLaborsForEmployeeId(employeeId));
        }

        [ServiceFilter(typeof(DuplicateLaborControlFilter<Labor>))]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeAsync(List<LaborDto> laborDto)
        {
            var laborList = _mapper.Map<List<Labor>>(laborDto);
            await _laborService.AddRangeAsync(laborList);
            return CreateActionResult(CustomResponseDto<List<LaborDto>>.Success(200, _mapper.Map<List<LaborDto>>(laborList)));
        }

        [ServiceFilter(typeof(DuplicateLaborControlFilter<Labor>))]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(LaborDto laborDto)
        {
            var labor = _mapper.Map<Labor>(laborDto);
            await _laborService.AddAsync(labor);
            return CreateActionResult(CustomResponseDto<LaborDto>.Success(201, _mapper.Map<LaborDto>(labor)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(LaborDto laborDto)
        {
            var labor = _mapper.Map<Labor>(laborDto);
            await _laborService.UpdateAsync(labor);
            return CreateActionResult(CustomResponseDto<LaborDto>.Success(204, _mapper.Map<LaborDto>(labor)));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(LaborDto laborDto)
        {
            var labor = _mapper.Map<Labor>(laborDto);
            await _laborService.RemoveAsync(labor);
            return CreateActionResult(CustomResponseDto<LaborDto>.Success(204, _mapper.Map<LaborDto>(labor)));
        }
    }
}
