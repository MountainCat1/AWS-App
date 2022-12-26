using MediatR;

namespace MessageBoardApp.Application.Service.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}