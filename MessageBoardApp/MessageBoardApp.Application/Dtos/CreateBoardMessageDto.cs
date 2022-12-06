namespace AppApi.Dtos;

public class CreateBoardMessageDto
{
    public CreateBoardMessageDto(string text)
    {
        Text = text;
    }

    public string Text { get; set; }
}