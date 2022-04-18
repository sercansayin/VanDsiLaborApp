using VanDsi.Core.Models;

namespace VanDsi.Core.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Task<Employee> GetEmployeeAndLaborsByEmployeeId(int employeeId);
    }
}
