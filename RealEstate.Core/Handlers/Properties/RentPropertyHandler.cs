namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

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
            Property property = await _unitOfWork.
                 Repository<Property>()
                .GetByAsync(p => p.Id == model.Id)
                .FirstAsync();

            TimeSpan dateFiff = model.EndDate - model.StartDate;

            decimal totalPrice = 0;
            if (property.SaleCategoryId == 1)
            {
                totalPrice = (decimal)dateFiff.TotalDays * property.Price;
            }
            else
            {
                int months = (int)(dateFiff.TotalDays % 30);
                totalPrice = months * property.Price;
            }

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
