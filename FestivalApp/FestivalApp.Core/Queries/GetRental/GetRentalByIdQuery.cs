using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Queries.GetRental
{
    public class GetRentalByIdQuery : IQuery<RentalModel>
    {
        public int Id { get; set; }

        public GetRentalByIdQuery(int id)
        {
            Id = id;
        }
    }
}
