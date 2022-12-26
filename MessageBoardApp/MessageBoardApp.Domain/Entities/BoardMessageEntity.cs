using System.ComponentModel.DataAnnotations;
using AppApi.Domain.Abstractions;

namespace AppApi.Domain.Entities;

public class BoardMessageEntity : IEntity
{
    [Key]
    public Guid Guid { get; set; }

    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}