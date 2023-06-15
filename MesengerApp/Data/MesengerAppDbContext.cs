using MesengerApp.Add.Configs;
using MesengerApp.Classes;
using Microsoft.EntityFrameworkCore;

namespace MesengerApp.Add;

public class MesengerAppDbContext : DbContext
{
    private const string connectionString = $"Server=localhost;Database=MesengerAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}