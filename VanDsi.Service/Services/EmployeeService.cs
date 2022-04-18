using AutoMapper;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;
using VanDsi.Core.Repositories;
using VanDsi.Core.Services;
using VanDsi.Core.UnitOfWorks;

namespace VanDsi.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public async Task<CustomResponseDto<EmployeeDto>> GetEmployeeAndLaborsByEmployeeId(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeAndLaborsByEmployeeId(employeeId);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CustomResponseDto<EmployeeDto>.Success(200, employeeDto);
        }
    }
}
