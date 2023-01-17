using MessageBoardApp.Domain.Abstractions;
using MessageBoardApp.Domain.Entities;

namespace MessageBoardApp.Domain.Events;

public class MessageCreatedDomainEvent : IDomainEvent
{
    public IEntity Entity { get; set; }
}