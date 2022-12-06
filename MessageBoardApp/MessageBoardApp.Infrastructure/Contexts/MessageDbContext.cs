using AppApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBoardApp.Infrastructure.Contexts;

public class MessageDbContext : DbContext
{
    public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options)
    {
        
    }

    public DbSet<BoardMessageEntity> BoardMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}