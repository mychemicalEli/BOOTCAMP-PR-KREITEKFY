using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Persistence;

public class KreitekfyContext:DbContext
{
    public KreitekfyContext(DbContextOptions<KreitekfyContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    //faltan los dbsets
}