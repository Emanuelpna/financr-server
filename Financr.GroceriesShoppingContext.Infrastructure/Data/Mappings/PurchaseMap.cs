using Financr.GroceriesShoppingContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financr.GroceriesShoppingContext.Infrastructure.Data.Mappings;

public class PurchaseMap
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchase");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalAmount)
            .IsRequired()
            .HasColumnType("DECIMAL");

        builder.Property(x => x.SupermarketName)
            .IsRequired()
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.PurchaseDate)
            .IsRequired()
            .HasColumnType("DATETIME");

        builder.Property(x => x.NfeAccessKey)
            .HasColumnType("NVARCHAR");

        builder.HasMany(x => x.Groceries)
            .WithOne(x => x.Purchase)
            .HasForeignKey(x => x.PurchaseId)
            .IsRequired();
    }
}