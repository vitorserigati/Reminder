using Microsoft.EntityFrameworkCore;
using Reminder.Domain.Entities;

namespace Reminder.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Todo> Todos => Set<Todo>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
