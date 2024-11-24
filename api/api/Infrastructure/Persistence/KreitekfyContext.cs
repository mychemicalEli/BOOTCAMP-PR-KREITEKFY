using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class KreitekfyContext : DbContext
{
    public KreitekfyContext(DbContextOptions<KreitekfyContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSongsHistory>()
            .HasOne(ush => ush.User)
            .WithMany()
            .HasForeignKey(ush => ush.UserId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<UserSongsHistory>()
            .HasOne(ush => ush.Song)
            .WithMany()
            .HasForeignKey(ush => ush.SongId)
            .OnDelete(DeleteBehavior.Cascade); 
        
        modelBuilder.Entity<User>()
            .Property(u => u.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();
        
        modelBuilder.Entity<Song>()
            .Property(i => i.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<UserSongsHistory> UserSongsHistories { get; set; }
}