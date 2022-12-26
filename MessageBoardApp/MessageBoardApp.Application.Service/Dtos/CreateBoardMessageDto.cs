namespace MessageBoardApp.Application.Service.Dtos;

public class CreateBoardMessageDto
{
    public CreateBoardMessageDto(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}