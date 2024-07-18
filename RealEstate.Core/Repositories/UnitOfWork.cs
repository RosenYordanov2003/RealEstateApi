namespace RealEstate.Data.Repositories
{
    using Contracts;
    using Data;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPropertyRepository _propertyRepository;
        public UnitOfWork(ApplicationDbContext dbContext, IPropertyRepository propertyRepository)
        {
            _dbContext = dbContext;
            _propertyRepository = propertyRepository;
        }

        public IPropertyRepository PropertyRepository => _propertyRepository; 

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
