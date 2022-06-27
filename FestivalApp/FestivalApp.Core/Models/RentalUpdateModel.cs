namespace FestivalApp.Core.Models
{
    public class RentalUpdateModel
    {
        public string Name { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int FestivalId { get; set; }
    }
}
