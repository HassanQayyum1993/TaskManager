
using TaskManager.Domain.Common;

namespace TaskManager.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
