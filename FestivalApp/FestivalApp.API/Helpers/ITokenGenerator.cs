using FestivalApp.Domain.Entities;

namespace FestivalApp.API.Helpers
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateToken(User user);
    }
}
