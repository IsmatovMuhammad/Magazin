using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Price).HasPrecision(18, 2);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);   
        builder.HasOne(x => x.Category).WithMany(x => x.Products).
        HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}