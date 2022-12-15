
using AppApi.Abstractions;
using AppApi.Dtos;

namespace AppApi.CQRS.Commands.CreateBoardMessage;

public record CreateBoardMessageCommand(CreateBoardMessageDto Dto) : ICommand;