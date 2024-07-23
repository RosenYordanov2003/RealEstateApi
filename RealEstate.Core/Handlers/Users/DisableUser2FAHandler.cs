namespace RealEstate.Core.Handlers.Users
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Core.Commands.Users;
    using Data.Data.Models;
    using Data.Repositories.Contracts;
    public class DisableUser2FAHandler : IRequestHandler<DisableUser2FACommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DisableUser2FAHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DisableUser2FACommand request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.Repository<User>().GetByAsync(u => u.UserName == request.userName).FirstAsync();
            user.TwoFactorEnabled = false;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
