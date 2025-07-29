// Services/EmailService.cs
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using portfolio_backend.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string name, string fromEmail, string message)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(
                _config["EmailSettings:Username"],
                _config["EmailSettings:Password"]
            ),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_config["EmailSettings:Username"]),
            Subject = "New Contact Form Submission",
            Body = $"Name: {name}\nEmail: {fromEmail}\nMessage:\n{message}",
            IsBodyHtml = false,
        };

        mailMessage.To.Add("dewminkasmitha30@gmail.com");

        await smtpClient.SendMailAsync(mailMessage);
    }
}
