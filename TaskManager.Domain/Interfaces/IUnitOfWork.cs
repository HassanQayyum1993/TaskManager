
namespace TaskManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : Common.BaseEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
