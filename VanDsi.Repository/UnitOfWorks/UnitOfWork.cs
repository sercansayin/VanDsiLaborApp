using VanDsi.Core.Repositories;
using VanDsi.Core.UnitOfWorks;
using VanDsi.Repository.Repositories;

namespace VanDsi.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private EmployeeRepository _employeeRepository;

        public IEmployeeRepository Employee =>
            _employeeRepository ??= new EmployeeRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
