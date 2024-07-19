namespace RealEstate.Core.Handlers.Subscription
{
    using MediatR;
    using Core.Commands.Subscription;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RemoveSubscriptionHandler : IRequestHandler<RemoveSubscriptionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveSubscriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription subscription  = await _unitOfWork.Repository<Subscription>()
                .GetAll(false, s => s.SubscriptionCategoryId == request.categoryId && s.UserId == request.userId)
                .FirstAsync();

            await _unitOfWork.Repository<Subscription>().DeleteAsync(subscription);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
