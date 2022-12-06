using Microsoft.EntityFrameworkCore;

namespace MessageBoardApp.Infrastructure.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
        
    }
}