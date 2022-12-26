using AppApi.Domain.Entities;
using AppApi.Domain.Repositories;
using MessageBoardApp.Infrastructure.Contexts;
using MessageBoardApp.Infrastructure.Generics;

namespace MessageBoardApp.Infrastructure.Repositories;

public class BoardMessageRepository : Repository<BoardMessageEntity, MessageDbContext>, IBoardMessageRepository
{
    public BoardMessageRepository(MessageDbContext dbContext) : base(dbContext)
    {
    }
}