using MediatR;

namespace MessageBoardApp.Domain.Abstractions;

public interface IDomainEventHandler<in T, TEntity> : INotificationHandler<T>
    where T : IDomainEvent<TEntity> where TEntity : IEntity
{
}