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
        modelBuilder.Entity<User>()
            .Property(u => u.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        modelBuilder.Entity<Song>()
            .Property(i => i.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        modelBuilder.Entity<UserSongs>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(ush => ush.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserSongs>()
            .HasOne<Song>()
            .WithMany()
            .HasForeignKey(ush => ush.SongId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<UserSongs> UserSongsHistories { get; set; }
}