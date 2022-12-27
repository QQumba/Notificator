using Microsoft.EntityFrameworkCore;
using Notificator.Data.Entities;

namespace Notificator.Data;

public class NotificatorDbContext : DbContext
{
    public NotificatorDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Message> Messages { get; set; } = null!;

    public virtual DbSet<Consumer> Consumers { get; set; } = null!;

    public virtual DbSet<Topic> Topics { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("notificator");
    }
}