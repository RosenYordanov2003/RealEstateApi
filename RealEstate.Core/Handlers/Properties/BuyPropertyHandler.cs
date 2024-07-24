namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class BuyPropertyHandler : IRequestHandler<BuyPropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyPropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(BuyPropertyCommand request, CancellationToken cancellationToken)
        {
            Property property = await _unitOfWork.Repository<Property>().GetByAsync(p => p.Id == request.propertyId)
                .FirstAsync();

            property.OwnerId = request.userId;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
