using Financr.GroceriesShoppingContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financr.GroceriesShoppingContext.Infrastructure.Data.Mappings;

public class CategoryMap
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("NVARCHAR");
    }
}