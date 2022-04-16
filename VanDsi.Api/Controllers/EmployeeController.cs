using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VanDsi.Api.Filters;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Services;

namespace VanDsi.Api.Controllers
{
    public class EmployeeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _service;

        public EmployeeController(IMapper mapper, IEmployeeService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Employee>))]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(200, employeeDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDto employeeDto)
        {
            var employeeEntity = await _service.AddAsync(_mapper.Map<Employee>(employeeDto));
            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(201, _mapper.Map<EmployeeDto>(employeeEntity)));
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveRange(List<EmployeeDto> employeesDtos)
        //{
        //    var employeesEntityes = await _service.AddRangeAsync(_mapper.Map<List<Employee>>(employeesDtos));
        //    var employeeList = _mapper.Map<List<EmployeeDto>>(employeesEntityes.ToList());
        //    return CreateActionResult(CustomResponseDto<List<EmployeeDto>>.Success(200, employeeList));
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDto employeeDto)
        {
            await _service.UpdateAsync(_mapper.Map<Employee>(employeeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
