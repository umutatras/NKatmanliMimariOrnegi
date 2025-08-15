using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NKatmanliMimariOrnegi.Entities;

namespace NKatmanliMimariOrnegi.DataAccess.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(x => x.Id);
    }
}
