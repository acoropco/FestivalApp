using FestivalApp.Domain.Entities;

namespace FestivalApp.API.Helpers
{
    public interface ITokenProvider
    {
        public Task<string> GenerateToken(User user);
    }
}
