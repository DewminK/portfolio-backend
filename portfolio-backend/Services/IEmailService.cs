namespace portfolio_backend.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string name, string fromEmail, string message);
        
    }
}
