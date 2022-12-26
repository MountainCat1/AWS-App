using MediatR;

namespace MessageBoardApp.Application.Service.Abstractions;

public interface ICommand<TResult> : IRequest<TResult>
{
}

public interface ICommand : ICommand<Unit>
{
}