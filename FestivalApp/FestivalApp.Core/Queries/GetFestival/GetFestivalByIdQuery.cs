using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Queries.GetFestival
{
    public class GetFestivalByIdQuery : IQuery<FestivalModel>
    {
        public int Id { get; set; }

        public GetFestivalByIdQuery(int id)
        {
            Id = id;
        }
    }
}
