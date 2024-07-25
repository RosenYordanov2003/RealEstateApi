namespace RealEstate.Core.Handlers.Pictures
{
    using MediatR;
    using Core.Commands.Pictures;
    using Data.Repositories.Contracts;
    using System.IO;
    using Data.Data.Models;
    using Core.Models.Pictures;

    public class CreatePictureHandler : IRequestHandler<CreatePictureCommand, PictureModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePictureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PictureModel> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            string fileName = string.Format($"{request.propertyId}_{request.file.FileName}");
            string filePath = Path.Combine(request.path, fileName);

            using (FileStream stream = new FileStream(Path.Combine(filePath), FileMode.Create))
            {
                await request.file.CopyToAsync(stream);
            }
            Picture picture = new Picture()
            {
                PropertyId = request.propertyId,
                ImgUrl = $"https://localhost:7039/{fileName}"
            };

            await _unitOfWork.Repository<Picture>().AddAsync(picture);
            await _unitOfWork.SaveChangesAsync();

            return new PictureModel() { Id = picture.Id, ImgUrl = picture.ImgUrl };
        }
    }
}
