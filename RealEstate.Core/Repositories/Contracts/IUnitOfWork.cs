namespace RealEstate.Data.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        IGenericRepository<T> Repository<T>() where T : class;
        IPropertyRepository PropertyRepository { get; }
    }
}
