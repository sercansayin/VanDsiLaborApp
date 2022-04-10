using VanDsi.Core.Models;
using VanDsi.Core.Repositories;
using VanDsi.Core.Services;
using VanDsi.Core.UnitOfWorks;

namespace VanDsi.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository) : base(unitOfWork, repository)
        {
            _employeeRepository = employeeRepository;
        }

        public override async Task UpdateAsync(Employee entity)
        {
            _employeeRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
