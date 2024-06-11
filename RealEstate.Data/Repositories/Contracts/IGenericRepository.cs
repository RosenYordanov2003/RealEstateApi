namespace RealEstate.Data.Repositories.Contracts
{
    using System.Linq;
    using System.Linq.Expressions;
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T?>> GetAllAsync(bool tracked = true, 
            Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(T entity);
        Task SaveAsync();
    }
}
