using Microsoft.EntityFrameworkCore;

namespace MessageBoardApp.Infrastructure.Contexts;

public class MessageDbContext : DbContext
{
    public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
    {
        
    }
}