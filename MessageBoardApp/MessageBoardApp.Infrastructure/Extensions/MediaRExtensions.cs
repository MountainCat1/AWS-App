using MediatR;
using MessageBoardApp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MessageBoardApp.Infrastructure.Extensions;

public static class MediaRExtensions
{
    public static IMediator DispatchDomainEvents(this IMediator mediator, DbContext dbContext)
    {
        var changedEntities = dbContext.ChangeTracker.Entries<IEntity>().Select(entry => entry.Entity);
        
        foreach (var entity in changedEntities)
        {
            DispatchEntityDomainEvents(mediator, entity);
        }

        return mediator;
    }

    private static void DispatchEntityDomainEvents(IMediator mediator, IEntity entity)
    {
        foreach (var domainEvent in entity.DomainEvents)
        {
            mediator.Send(domainEvent);
        }
    }
}