using AppApi.Domain.Abstractions;
using AppApi.Domain.Entities;
using AppApi.Domain.Repositories;
using MessageBoardApp.Infrastructure.Contexts;
using MessageBoardApp.Infrastructure.Generics;

namespace MessageBoardApp.Infrastructure.Repositories;

public class MessageEntityRepository : Repository<MessageEntity, MessageDbContext>, IMessageEntityRepository
{
    public MessageEntityRepository(MessageDbContext dbContext) : base(dbContext)
    {
    }
}