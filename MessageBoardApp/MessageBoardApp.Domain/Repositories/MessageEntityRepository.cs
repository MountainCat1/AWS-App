using MessageBoard.Domain.Abstractions;
using MessageBoard.Domain.Entities;

namespace MessageBoard.Domain.Repositories;

public interface IBoardMessageRepository :  IRepository<BoardMessageEntity>
{
    // Intentionally empty
}