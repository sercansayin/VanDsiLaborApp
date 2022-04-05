using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanDsi.Core.Models;

namespace VanDsi.Core.Repositories
{
    public interface ILaborRepository: IGenericRepository<Labor>
    {
        Task<List<Labor>> GetLaborsForEmployeeId(int employeId);
    }
}
