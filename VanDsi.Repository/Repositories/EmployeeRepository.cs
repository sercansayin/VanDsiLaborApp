using Microsoft.EntityFrameworkCore;
using VanDsi.Core.Models;
using VanDsi.Core.Repositories;

namespace VanDsi.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<Employee> GetEmployeeAndLaborsByEmployeeId(int employeeId)
        {
            return await _context.Employees.Include(x => x.Labors).SingleOrDefaultAsync(e => e.Id == employeeId);
        }
    }
}