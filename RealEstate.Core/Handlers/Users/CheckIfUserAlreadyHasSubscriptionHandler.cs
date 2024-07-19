namespace RealEstate.Core.Handlers.Users
{
    using MediatR;
    using Queries.Users;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class CheckIfUserAlreadyHasSubscriptionHandler : IRequestHandler<CheckIfUserAlreadyHasSubscriptionQuery, bool>
    {
        private IUnitOfWork _unitOfWork;
        public CheckIfUserAlreadyHasSubscriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CheckIfUserAlreadyHasSubscriptionQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Subscription>()
               .CheckIfExistsByIdAsync(s => s.UserId == request.userId && s.SubscriptionCategoryId == request.propertyCategoryId);
                
        }
    }
}
