using Domain.Entities.Common;

namespace Application.Abstractions.Repositories.Common
{
    public interface IWriteRepository<T> : IRepository<T> where T : class, IEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);

        Task<int> SaveChangesAsync();
    }
}
