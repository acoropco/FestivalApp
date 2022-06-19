using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetRental
{
    public class GetRentalByIdQuery : IRequest<RentalModel>
    {
        public int Id { get; set; }

        public GetRentalByIdQuery(int id)
        {
            Id = id;
        }
    }
}
