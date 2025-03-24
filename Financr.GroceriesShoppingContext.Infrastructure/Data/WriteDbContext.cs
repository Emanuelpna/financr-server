using Financr.GroceriesShoppingContext.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Financr.GroceriesShoppingContext.Infrastructure.Data;

public class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Grocery> Groceries { get; set; } = null!;
    public DbSet<GroceryPrice> GroceryPrices { get; set; } = null!;
    public DbSet<Purchase> Purchases { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}