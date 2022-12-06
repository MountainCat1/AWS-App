
using AppApi.Abstractions;
using AppApi.Dtos;
using MediatR;

namespace AppApi.CQRS.Commands.CreateBoardMessage;

public class CreateBoardMessageCommand : ICommand
{
    public CreateBoardMessageCommand(CreateBoardMessageDto dto)
    {
        Dto = dto;
    }

    public CreateBoardMessageDto Dto { get; set; }
}