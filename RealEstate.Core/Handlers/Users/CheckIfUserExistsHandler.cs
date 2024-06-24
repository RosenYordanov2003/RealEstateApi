namespace RealEstate.Core.Handlers.Users
{
    using System.Threading.Tasks;
    using System.Threading;
    using Microsoft.AspNetCore.Identity;
    using MediatR;
    using Queries.Users;
    using Data.Data.Models;

    public class CheckIfUserExistsHandler : IRequestHandler<CheckIfUserExistsByIdQuery, bool>
    {
        private readonly UserManager<User> _userManager;
        public CheckIfUserExistsHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CheckIfUserExistsByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByIdAsync(request.userId.ToString());

            return user == null ? false : true;
        }
    }
}
