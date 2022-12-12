
using AppApi.Abstractions;
using AppApi.Dtos;
using MediatR;

namespace AppApi.CQRS.Commands.CreateBoardMessage;

public record CreateBoardMessageCommand(CreateBoardMessageDto Dto) : ICommand;