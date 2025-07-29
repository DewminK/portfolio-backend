// Controllers/ContactController.cs
using Microsoft.AspNetCore.Mvc;
using portfolio_backend.Services;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IEmailService _emailService;

    public ContactController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public class ContactRequest
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
    }

    [HttpPost]
    public async Task<IActionResult> SendContactForm([FromBody] ContactRequest request)
    {
        await _emailService.SendEmailAsync(request.Name, request.Email, request.Message);
        return Ok(new { message = "Email sent successfully!" });
    }
}
