using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Common;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
