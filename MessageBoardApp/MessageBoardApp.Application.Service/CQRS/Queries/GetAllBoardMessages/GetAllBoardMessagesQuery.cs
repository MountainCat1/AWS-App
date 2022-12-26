using MessageBoardApp.Application.Service.Abstractions;
using MessageBoardApp.Application.Service.Dtos;

namespace MessageBoardApp.Application.Service.CQRS.Queries.GetAllBoardMessages;

public record GetAllBoardMessagesQuery() : IQuery<ICollection<BoardMessageDto>>;