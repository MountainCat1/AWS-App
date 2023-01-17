using MessageBoardApp.Domain.Abstractions;
using MessageBoardApp.Domain.Entities;

namespace MessageBoardApp.Domain.Repositories;

public interface IBoardMessageRepository :  IRepository<BoardMessageEntity>
{
    // Intentionally empty
}