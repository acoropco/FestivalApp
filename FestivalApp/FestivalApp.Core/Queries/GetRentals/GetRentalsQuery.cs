using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetRentals
{
    public class GetRentalsQuery : IRequest<List<RentalModel>>
    {
        public GetRentalsQuery()
        {

        }
    }
}
