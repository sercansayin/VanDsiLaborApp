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
