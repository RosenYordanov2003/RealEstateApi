namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Core.Queries.Properties;
    using Data.Data.Models;
    using Data.Repositories.Contracts;
    public class CheckIfPropertyIsAlreadyOwnedByUserHandler : IRequestHandler<CheckIfPropertyIsAlreadyOwnedByUserQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CheckIfPropertyIsAlreadyOwnedByUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CheckIfPropertyIsAlreadyOwnedByUserQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Property>().
                CheckIfExistsByIdAsync(p => p.Id == request.propertyId && p.OwnerId == request.userId);
        }
    }
}
