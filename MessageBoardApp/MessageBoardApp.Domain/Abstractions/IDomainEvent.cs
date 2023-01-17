using MediatR;

namespace MessageBoardApp.Domain.Abstractions;

public interface IDomainEvent : INotification
{
}

public interface IDomainEvent<TEntity>  : IDomainEvent 
    where TEntity : IEntity
{
    public IEntity Entity { get; set; }
}