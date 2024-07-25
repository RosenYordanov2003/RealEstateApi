namespace RealEstate.Core.Handlers.Pictures
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Commands.Pictures;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class DeletePictureHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeletePictureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            DeleteImgIfExistsOnTheDisk(request.webRoothPath, request.imgFileName);

            Picture picture = await _unitOfWork.Repository<Picture>()
                .GetByAsync(p => p.Id == request.imgId)
                .FirstAsync();

            await _unitOfWork.Repository<Picture>().DeleteAsync(picture);
            await _unitOfWork.SaveChangesAsync();
        }

        private void DeleteImgIfExistsOnTheDisk(string path, string fileNameToFind)
        {
            string fullPath = Path.Combine(path, fileNameToFind);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
