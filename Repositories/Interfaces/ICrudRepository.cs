using System.Linq.Expressions;

namespace DamInspectionApi.Repositories.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> SaveChangesAsync();
    }
}
