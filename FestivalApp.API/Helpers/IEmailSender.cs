using System.Threading.Tasks;
using FestivalApp.API.Models;

namespace FestivalApp.API.Helpers
{
  public interface IEmailSender
  {
    Task SendEmailAsync(Message message);
  }
}