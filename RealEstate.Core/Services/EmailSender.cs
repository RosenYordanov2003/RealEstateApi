namespace RealEstate.Core.Services
{
    using System.Net.Mail;
    using System.Net;
    using Contracts.Email;

    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string appEmail = "fashionstore998474@gmail.com";
            string appEmailPassword = "joyw xmyg bwuf fopm";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(appEmail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(appEmail, appEmailPassword),
                EnableSsl = true,
            };

            try
            {
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                smtpClient.Dispose();
            }
        }
    }
}
