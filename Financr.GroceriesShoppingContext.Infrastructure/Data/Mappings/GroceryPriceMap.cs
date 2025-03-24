using Financr.GroceriesShoppingContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financr.GroceriesShoppingContext.Infrastructure.Data.Mappings;

public class GroceryPriceMap
{
    public void Configure(EntityTypeBuilder<GroceryPrice> builder)
    {
        builder.ToTable("GroceryPrice");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("DECIMAL");

        builder.OwnsOne(x => x.Quantity)
            .Property(x => x.Quantity)
            .HasColumnName("GroceryQuantity");
        
        builder.OwnsOne(x => x.Quantity)
            .Property(x => x.UnitType)
            .HasColumnName("GroceryUnitType");

        builder.HasOne(x => x.Grocery)
            .WithOne(x => x.GroceryPrice)
            .HasForeignKey<Grocery>(x => x.GroceryPriceId);
    }
}