namespace RealEstate.Data.Repositories.Contracts
{
    using System.Linq;
    using System.Linq.Expressions;
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        IQueryable<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll(bool tracked = true, 
            Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(T entity);
        Task SaveAsync();
        Task<bool> CheckIfExistsByIdAsync(Expression<Func<T, bool>> expression);
    }
}
