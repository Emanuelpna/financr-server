using Financr.GroceriesShoppingContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financr.GroceriesShoppingContext.Infrastructure.Data.Mappings;

public class GroceryMap
{
    public void Configure(EntityTypeBuilder<Grocery> builder)
    {
        builder.ToTable("Purchase");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(256)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Code)
            .IsRequired()
            .HasColumnType("NVARCHAR");
            
        builder.OwnsOne(
            x => x.GroceryPrice, 
            gp =>
            {
                gp.OwnsOne(x => x.Quantity);
            }
        );
    }
}