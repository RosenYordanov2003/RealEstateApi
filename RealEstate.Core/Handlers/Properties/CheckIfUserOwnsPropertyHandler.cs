namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Queries.Properties;
    using Data.Repositories.Contracts;
    using RealEstate.Data.Data.Models;

    public class CheckIfUserOwnsPropertyHandler : IRequestHandler<CheckIfUserOwnsPropertyQuery, bool>
    {
        private readonly IUnitOfWork _uinitOfWork;
        public CheckIfUserOwnsPropertyHandler(IUnitOfWork uinitOfWork)
        {
            _uinitOfWork = uinitOfWork;
        }

        public Task<bool> Handle(CheckIfUserOwnsPropertyQuery request, CancellationToken cancellationToken)
        {
            return _uinitOfWork.Repository<Property>()
                .CheckIfExistsByIdAsync(p => p.OwnerId == request.userId && p.Id == request.propertyId);
        }
    }
}
