using FestivalApp.Core.Models;

namespace FestivalApp.Core.Interfaces
{
    public interface IEmailMessageProvider
    {
        public Message GenerateEmailMessage(EmailMessageConfiguration emailMessageConfiguration);
    }
}
