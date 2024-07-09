namespace RealEstate.Core.Handlers.Properties
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands.Properties;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class BookPropertyHandler : IRequestHandler<BookPropertyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookPropertyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(BookPropertyCommand request, CancellationToken cancellationToken)
        {
            var model = request.model;
            Property property = await _unitOfWork.
                 Repository<Property>()
                .GetByAsync(p => p.Id == model.Id)
                .FirstAsync();

            TimeSpan dateFiff = model.EndDate - model.StartDate;


            PropertiesRents entity = new PropertiesRents()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PropertyId = model.Id,
                UserId = request.userId,
                TotalPrice = (decimal)dateFiff.TotalDays * property.Price
            };

            await _unitOfWork.Repository<PropertiesRents>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
