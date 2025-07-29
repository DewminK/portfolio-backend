using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using portfolio_backend.Class;

namespace portfolio_backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string name, string email, string message)
        {
            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password)
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_emailSettings.Username),
                Subject = "New Contact Form Submission",
                Body = $"Name: {name}\nEmail: {email}\nMessage:\n{message}",
                IsBodyHtml = false
            };

            mail.To.Add("dewminkasmitha30@gmail.com");

            await smtp.SendMailAsync(mail);
        }
    }
}
