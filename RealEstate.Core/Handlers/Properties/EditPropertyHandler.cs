namespace RealEstate.Core.Handlers.Properties
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;
    using Models.Property;

    public class EditPropertyHandler : IRequestHandler<EditPropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditPropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditPropertyCommand request, CancellationToken cancellationToken)
        {
            EditPropertyModel model = request.model;

            Property propertyToUpdate = await _unitOfWork
                .Repository<Property>()
                .GetByAsync(p => p.Id == request.id)
                .FirstAsync();

            propertyToUpdate.CityId = model.CityId;
            propertyToUpdate.Address = model.Address;
            propertyToUpdate.FloorNumber = model.FloorNumber;
            propertyToUpdate.Longitude = model.Longitude;
            propertyToUpdate.Latitude = model.Latitude;
            propertyToUpdate.Price = model.Price;
            propertyToUpdate.BathRoomsCount = model.BathRoomsCount;
            propertyToUpdate.BedRoomsCount = model.BedRoomsCount;
            propertyToUpdate.Description = model.Description;
            propertyToUpdate.SaleCategoryId = model.SaleCategoryId;
            propertyToUpdate.PropertyCategoryId = model.PropertyCategoryId;
            propertyToUpdate.Name = model.Name;
            propertyToUpdate.SquareMeters = model.SquareMeters;

            await _unitOfWork.Repository<Property>().UpdateAsync(propertyToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
