
namespace RealEstate.Core.Handlers.Subscription
{
    using System.Threading.Tasks;
    using System.Threading;
    using MediatR;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using RealEstate.Core.Commands.Subscription;

    public class CreateSubscriptionHandler : IRequestHandler<CreateSubscriptionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateSubscriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription subscription = new Subscription()
            {
                SubscriptionCategoryId = request.model.SubscriptionCategoryId,
                UserId = request.userId
            };

            await _unitOfWork.Repository<Subscription>().AddAsync(subscription);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
