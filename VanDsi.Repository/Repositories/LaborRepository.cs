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

        public override void Update(Labor entity)
        {
            _context.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            _context.Entry(entity).Property(x => x.EmployeeId).IsModified = false;
            _context.Entry(entity).Property(x => x.UserId).IsModified = false;
            base.Update(entity);
        }

        public async Task<List<Labor>> GetLaborsForEmployeeId(int employeId)
        {
            return await _context.Labors.Include(x => x.EmployeeId == employeId).ToListAsync();
        }
    }
}
