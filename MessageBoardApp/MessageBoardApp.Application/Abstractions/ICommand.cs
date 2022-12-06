using MediatR;

namespace MessageBoardApp.Abstractions;

public interface ICommand<TResult> : IRequest<TResult>
{
}

public interface ICommand : ICommand<Unit>
{
}