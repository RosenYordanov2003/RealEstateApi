namespace RealEstate.Data.Repositories
{
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Data;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            //await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await SaveAsync();
            }
        }

        public IQueryable<T> GetAll(bool tracked = true,
            Expression<Func<T, bool>> filter = null, Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy = null)
        {
            IQueryable<T> query = tracked ? _dbSet : _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                var compiledOrderBy = orderBy.Compile();
                return compiledOrderBy(query);
            }
            return query;
        }
        public async Task<bool> CheckIfExistsByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AnyAsync(expression);
        }
        public IQueryable<T> GetByAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            //await SaveAsync();
        }
    }
}
