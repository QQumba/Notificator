using Microsoft.EntityFrameworkCore;
using Notificator.Data.Entities;

namespace Notificator.Data;

public class NotificatorDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<Channel> Channels { get; set; } = null!;

    public DbSet<Message> Messages { get; set; } = null!;

    public DbSet<Consumer> Consumers { get; set; } = null!;
    
    public DbSet<Topic> Topics { get; set; } = null!;
}