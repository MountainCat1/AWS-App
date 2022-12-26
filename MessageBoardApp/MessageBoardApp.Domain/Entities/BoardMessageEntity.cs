using System.ComponentModel.DataAnnotations;
using MessageBoard.Domain.Abstractions;

namespace MessageBoard.Domain.Entities;

public class BoardMessageEntity : IEntity
{
    [Key]
    public Guid Guid { get; set; }

    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}