namespace RealEstate.Core.Handlers.Properties
{
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using RealEstate.Data.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RentPropertyHandler : IRequestHandler<RentPropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RentPropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RentPropertyCommand request, CancellationToken cancellationToken)
        {
            var model = request.model;
            decimal propertyPrice = await _unitOfWork.
                 Repository<Property>()
                .GetByAsync(p => p.Id == model.Id)
                .Select(p => p.Price)
                .FirstAsync();

            TimeSpan dateFiff = model.EndDate - model.StartDate;

            decimal totalPrice = (decimal)dateFiff.TotalDays * propertyPrice;

            PropertiesRents entity = new PropertiesRents()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PropertyId = model.Id,
                UserId = request.userId,
                TotalPrice =  totalPrice,
            };

            await _unitOfWork.Repository<PropertiesRents>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
