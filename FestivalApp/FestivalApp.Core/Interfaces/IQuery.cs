using MediatR;

namespace FestivalApp.Core.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
