namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class RecoverPropertyHandler : IRequestHandler<RecoverPropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecoverPropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RecoverPropertyCommand request, CancellationToken cancellationToken)
        {
            Property property = await _unitOfWork.Repository<Property>()
                 .GetByAsync(p => p.Id == request.propertyId)
                 .FirstAsync();

            property.IsDeleted = false;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
