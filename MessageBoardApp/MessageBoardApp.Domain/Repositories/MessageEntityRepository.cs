using MessageBoardApp.Application.Domain.Abstractions;
using MessageBoardApp.Application.Domain.Entities;

namespace MessageBoardApp.Application.Domain.Repositories;

public interface IBoardMessageRepository :  IRepository<BoardMessageEntity>
{
    // Intentionally empty
}