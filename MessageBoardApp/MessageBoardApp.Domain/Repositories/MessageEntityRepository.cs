using AppApi.Domain.Abstractions;
using AppApi.Domain.Entities;

namespace AppApi.Domain.Repositories;

public interface IBoardMessageRepository :  IRepository<BoardMessageEntity>
{
    // Intentionally empty
}