using AppApi.Abstractions;
using AppApi.Domain.Entities;
using AppApi.Dtos;

namespace AppApi.CQRS.Queries.GetAllBoardMessages;

public class GetAllBoardMessagesQuery : IQuery<ICollection<BoardMessageDto>>
{
    // Intentionally empty
}