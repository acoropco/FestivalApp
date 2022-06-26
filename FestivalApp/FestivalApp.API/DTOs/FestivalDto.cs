namespace FestivalApp.API.DTOs
{
    public class FestivalDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string TicketUrl { get; set; }

        public bool IsLiked { get; set; }
    }
}