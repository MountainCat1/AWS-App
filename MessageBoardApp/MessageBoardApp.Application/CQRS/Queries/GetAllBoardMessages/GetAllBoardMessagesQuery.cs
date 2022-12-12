using AppApi.Abstractions;
using AppApi.Domain.Entities;
using AppApi.Dtos;

namespace AppApi.CQRS.Queries.GetAllBoardMessages;

public record GetAllBoardMessagesQuery() : IQuery<ICollection<BoardMessageDto>>;