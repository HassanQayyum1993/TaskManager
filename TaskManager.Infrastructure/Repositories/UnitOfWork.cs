using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Common;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<string, object> _repositories = new();

        public UnitOfWork(DbContext context) => _context = context;

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var type = typeof(T).FullName ?? typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            { 
                var repo = new GenericRepository<T>(_context);
                _repositories.Add(type, repo);
            }

            return (IRepository<T>)_repositories[type];
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
