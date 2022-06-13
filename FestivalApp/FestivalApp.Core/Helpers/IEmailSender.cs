using FestivalApp.Domain.Models;

namespace FestivalApp.Core.Helpers
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}