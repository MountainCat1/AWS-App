namespace MessageBoardApp.Application.Service.Dtos;

public class BoardMessageDto
{
    public Guid Guid { get; set; }

    public string Text { get; set; }

    public DateTime PostTime { get; set; }
}