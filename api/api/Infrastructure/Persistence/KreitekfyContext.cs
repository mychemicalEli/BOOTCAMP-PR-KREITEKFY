using api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class KreitekfyContext : DbContext
{
    public KreitekfyContext(DbContextOptions<KreitekfyContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder)
    {
        base.OnConfiguring(_optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(i => i.Role)
            .WithMany()
            .HasForeignKey(i => i.RoleId)
            .IsRequired();

        modelBuilder.Entity<Album>()
            .HasOne(i => i.Artist)
            .WithMany()
            .HasForeignKey(i => i.ArtistId)
            .IsRequired();

        modelBuilder.Entity<Song>()
            .HasOne(i => i.Genre)
            .WithMany(g => g.Songs)
            .HasForeignKey(i => i.GenreId)
            .IsRequired();

        modelBuilder.Entity<Song>()
            .HasOne(i => i.Album)
            .WithMany()
            .HasForeignKey(i => i.AlbumId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);


        /*modelBuilder.Entity<UserSongs>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(ush => ush.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserSongs>()
            .HasOne<Song>()
            .WithMany()
            .HasForeignKey(ush => ush.SongId)
            .OnDelete(DeleteBehavior.Cascade);*/
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<UserSongs> UserSongsHistories { get; set; }
}