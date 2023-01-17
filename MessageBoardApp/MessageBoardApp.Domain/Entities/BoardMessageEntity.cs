using System.ComponentModel.DataAnnotations;
using MessageBoardApp.Domain.Abstractions;

namespace MessageBoardApp.Domain.Entities;

public class BoardMessageEntity : Entity
{
    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}