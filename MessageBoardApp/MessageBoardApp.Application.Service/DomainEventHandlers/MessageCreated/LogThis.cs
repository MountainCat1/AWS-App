using MessageBoardApp.Domain.Abstractions;
using MessageBoardApp.Domain.Entities;
using MessageBoardApp.Domain.Events;

namespace MessageBoardApp.Application.Service.DomainEventHandlers.MessageCreated;

public class LogThis : IDomainEventHandler<MessageCreatedDomainEvent>
{
    public async Task Handle(MessageCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"XDDD: {notification.Entity.Id}");
    }
}