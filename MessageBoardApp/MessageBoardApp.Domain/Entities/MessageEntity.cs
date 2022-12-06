using System.ComponentModel.DataAnnotations;
using AppApi.Domain.Abstractions;

namespace AppApi.Domain.Entities;

public class MessageEntity : IEntity
{
    [Key]
    public Guid Guid { get; set; }

    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}