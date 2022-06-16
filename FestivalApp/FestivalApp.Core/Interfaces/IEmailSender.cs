using FestivalApp.Core.Models;

namespace FestivalApp.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}