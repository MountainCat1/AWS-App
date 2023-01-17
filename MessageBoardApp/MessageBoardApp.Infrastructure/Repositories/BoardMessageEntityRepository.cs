using MediatR;
using MessageBoardApp.Domain.Entities;
using MessageBoardApp.Domain.Repositories;
using MessageBoardApp.Infrastructure.Contexts;
using MessageBoardApp.Infrastructure.Generics;

namespace MessageBoardApp.Infrastructure.Repositories;

public class BoardMessageRepository : Repository<BoardMessageEntity, MessageDbContext>, IBoardMessageRepository
{
    public BoardMessageRepository(MessageDbContext dbContext, IMediator mediator) : base(dbContext, mediator)
    {
    }
}