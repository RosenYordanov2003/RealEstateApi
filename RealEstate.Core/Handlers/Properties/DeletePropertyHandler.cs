namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using RealEstate.Core.Commands.Properties;

    public class DeletePropertyHandler : IRequestHandler<DeletePropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            Property propertyToDelete = await _unitOfWork.Repository<Property>().GetByAsync(p => p.Id == request.propertyId)
                 .FirstAsync();

            propertyToDelete.IsDeleted = true;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
