using Microsoft.EntityFrameworkCore;
using VanDsi.Core.Models;
using VanDsi.Core.Repositories;

namespace VanDsi.Repository.Repositories
{
    public class LaborRepository : GenericRepository<Labor>, ILaborRepository
    {
        public LaborRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Labor>> GetLaborsForEmployeeId(int employeId)
        {
            return await _context.Labors.Include(x => x.EmployeeId == employeId).ToListAsync();
        }
    }
}
