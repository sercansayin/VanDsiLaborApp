using VanDsi.Core.DTOs;
using VanDsi.Core.Models;

namespace VanDsi.Core.Services
{
    public interface IEmployeeService : IService<Employee>
    {
        public Task<CustomResponseDto<EmployeeDto>> GetEmployeeAndLaborsByEmployeeId(int employeeId);
    }
}
