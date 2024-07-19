namespace RealEstate.Core.Handlers.Users
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Queries.Users;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class GetUserEmailsHandler : IRequestHandler<GetUserEmailsQuery, IEnumerable<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserEmailsHandler(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<string>> Handle(GetUserEmailsQuery request, CancellationToken cancellationToken)
        {
           return await _unitOfWork.Repository<User>()
                .GetAll(false, u => u.Subscriptions
                .Any(s => s.SubscriptionCategoryId == request.categoryId))
                .Select(u => u.Email)
                .ToArrayAsync();
        }
    }
}
