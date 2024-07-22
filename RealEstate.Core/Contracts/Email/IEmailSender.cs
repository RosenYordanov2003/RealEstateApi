namespace RealEstate.Core.Contracts.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userEmail, string subject, string htmlMessage);

    }
}
