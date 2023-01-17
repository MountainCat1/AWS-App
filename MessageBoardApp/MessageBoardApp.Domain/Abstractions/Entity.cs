using System.ComponentModel.DataAnnotations;

namespace MessageBoardApp.Domain.Abstractions;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
}

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvent.AsReadOnly();

    private List<IDomainEvent> _domainEvent = new();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvent.Add(domainEvent);
    }
}