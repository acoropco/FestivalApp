using MediatR;

namespace FestivalApp.Core.Interfaces
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
