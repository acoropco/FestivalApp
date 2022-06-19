using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace FestivalApp.Core.Providers
{
    public class EmailMessageProvider : IEmailMessageProvider
    {
        private const string Token = "token";
        private const string Email = "email";

        public Message GenerateEmailMessage(EmailMessageConfiguration emailMessageConfiguration)
        {
            var param = new Dictionary<string, string>
            {
                { Token, emailMessageConfiguration.Token },
                { Email, emailMessageConfiguration.EmailParam }
            };
            var callback = QueryHelpers.AddQueryString(emailMessageConfiguration.ClientURI, param);
            var message = new Message(emailMessageConfiguration.EmailTo, emailMessageConfiguration.Subject, callback);

            return message;
        }
    }
}
