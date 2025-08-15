using Microsoft.EntityFrameworkCore;
using NKatmanliMimariOrnegi.Entities;

namespace NKatmanliMimariOrnegi.DataAccess.Contexts;

public class NKatmanliMimariOrnegiDbContext : DbContext
{
    public NKatmanliMimariOrnegiDbContext(DbContextOptions<NKatmanliMimariOrnegiDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(NKatmanliMimariOrnegiDbContext).Assembly);
    }
    public DbSet<Product> Products { get; set; }
}
