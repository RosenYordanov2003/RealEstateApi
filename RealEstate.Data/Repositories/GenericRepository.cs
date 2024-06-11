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
            await SaveAsync();
        }

        public async Task DeleteByIdAsync(T entity)
        {
            if (entity != null)
            {
                _dbContext.Remove(entity);
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<T?>> GetAllAsync(bool tracked = true, 
            Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(orderBy != null)
            {
                return await orderBy(query).ToArrayAsync();
            }
            return await query.ToArrayAsync();
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
