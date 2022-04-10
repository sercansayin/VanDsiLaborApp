using VanDsi.Core.Models;

namespace VanDsi.Core.Repositories
{
    public interface ILaborRepository : IGenericRepository<Labor>
    {
        Task<List<Labor>> GetLaborsForEmployeeId(int employeId);
    }
}
