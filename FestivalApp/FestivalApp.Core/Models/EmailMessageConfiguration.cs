namespace FestivalApp.Core.Models
{
    public class EmailMessageConfiguration
    {
        public IEnumerable<string> EmailTo { get; set; }

        public string EmailParam { get; set; }

        public string ClientURI { get; set; }

        public string Token { get; set; }

        public string Subject { get; set; }
    }
}
