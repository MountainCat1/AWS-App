using System.ComponentModel.DataAnnotations;
using MessageBoardApp.Application.Domain.Abstractions;

namespace MessageBoardApp.Application.Domain.Entities;

public class BoardMessageEntity : IEntity
{
    [Key]
    public Guid Guid { get; set; }

    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}