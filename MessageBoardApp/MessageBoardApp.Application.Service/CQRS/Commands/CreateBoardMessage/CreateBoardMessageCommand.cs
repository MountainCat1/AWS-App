using MessageBoardApp.Application.Service.Abstractions;
using MessageBoardApp.Application.Service.Dtos;

namespace MessageBoardApp.Application.Service.CQRS.Commands.CreateBoardMessage;

public record CreateBoardMessageCommand(CreateBoardMessageDto Dto) : ICommand;