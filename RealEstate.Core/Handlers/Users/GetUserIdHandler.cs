namespace RealEstate.Core.Handlers.Users
{
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.AspNetCore.Identity;
    using MediatR;
    using Data.Data.Models;
    using Core.Queries.Users;

    public class GetUserIdHandler : IRequestHandler<GetUserIdQuery, Guid>
    {
        private readonly UserManager<User> _userManager;
        public GetUserIdHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Guid> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByNameAsync(request.userName);

            return user.Id;
        }
    }
}
