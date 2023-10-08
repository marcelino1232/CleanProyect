using CleanProyect.Application.Models;

namespace CleanProyect.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
