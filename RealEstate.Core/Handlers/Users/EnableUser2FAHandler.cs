namespace RealEstate.Core.Handlers.Users
{
    using Microsoft.EntityFrameworkCore;
    using MediatR;
    using Core.Commands.Users;
    using Data.Repositories.Contracts;
    using Data.Data.Models;

    public class EnableUser2FAHandler : IRequestHandler<EnableUser2FACommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EnableUser2FAHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(EnableUser2FACommand request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Repository<User>().GetByAsync(u => u.UserName == request.userName).FirstAsync();

            user.TwoFactorEnabled = true;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
