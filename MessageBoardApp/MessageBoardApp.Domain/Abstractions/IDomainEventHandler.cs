using MediatR;

namespace MessageBoardApp.Domain.Abstractions;

public interface IDomainEventHandler<in T> : INotificationHandler<T>
    where T : IDomainEvent
{
}