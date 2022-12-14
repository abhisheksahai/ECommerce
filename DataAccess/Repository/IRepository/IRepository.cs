using System.Linq.Expressions;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);
    }
}