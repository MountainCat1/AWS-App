using MediatR;

namespace MessageBoardApp.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}