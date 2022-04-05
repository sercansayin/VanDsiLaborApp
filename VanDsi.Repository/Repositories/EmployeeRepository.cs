using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override void Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            _context.Employees.Update(entity);
        }
    }
}
