using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.Repositories;

namespace VanDsi.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        Task CommitAsync();
        void Commit();
    }
}
