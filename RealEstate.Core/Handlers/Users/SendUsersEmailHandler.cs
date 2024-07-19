namespace RealEstate.Core.Handlers.Users
{
    using MediatR;
    using Queries.Users;
    using Core.Contracts.Email;

    public class SendUsersEmailHandler : IRequestHandler<SendUsersEmailQuery>
    {
        private readonly IEmailSender _emailSender;
        public SendUsersEmailHandler(IEmailSender emailSender)
        {
           _emailSender = emailSender;
        }
        public async Task Handle(SendUsersEmailQuery request, CancellationToken cancellationToken)
        {
            foreach (string email in request.emails)
            {
               await _emailSender.SendEmailAsync(email, "Subscription", "<h1>You have recieved Nottification </h1>");
            }
        }
    }
}
