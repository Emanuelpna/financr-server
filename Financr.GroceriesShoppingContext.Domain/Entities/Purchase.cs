using Financr.GroceriesShoppingContext.Domain.Aggregates.GroceryAggregate;
using Financr.GroceriesShoppingContext.Domain.Validators;

namespace Financr.GroceriesShoppingContext.Domain.Entities;

public class Purchase : Entity, IValidator<DomainErrorValidation>
{
    public List<DomainErrorValidation> Errors { get; set; } = [];
   
    public Purchase(Guid id, DateTimeOffset purchaseDate, string supermarketName, string nfeAccessKey, decimal totalAmount) : base()
    {
        Id = id;
        PurchaseDate = purchaseDate;
        SupermarketName = supermarketName;
        NfeAccessKey = nfeAccessKey;
        TotalAmount = totalAmount;
    }
    
    public Purchase(DateTimeOffset purchaseDate, string supermarketName, string nfeAccessKey, decimal totalAmount) : base()
    {
        PurchaseDate = purchaseDate;
        SupermarketName = supermarketName;
        NfeAccessKey = nfeAccessKey;
        TotalAmount = totalAmount;
    }
    
    public Purchase(DateTimeOffset purchaseDate, string supermarketName, string nfeAccessKey, decimal totalAmount, IList<Grocery> groceries) : base()
    {
        PurchaseDate = purchaseDate;
        SupermarketName = supermarketName;
        NfeAccessKey = nfeAccessKey;
        TotalAmount = totalAmount;
        Groceries = groceries;
    }
    
    public DateTimeOffset PurchaseDate { get; private set; }
    
    public string SupermarketName { get; private set; }
    
    public string NfeAccessKey { get; private set; }
    
    public decimal TotalAmount { get; private set; }

    public IList<Grocery> Groceries { get; private set; } = new List<Grocery>();

    public void AddGrocery(Grocery grocery)
    {
        if (Groceries.Any(groceryInPurchase => groceryInPurchase.Code == grocery.Code))
        {
            Errors.Add(new DomainErrorValidation(nameof(Purchase), "Não é possível adicionar produto repetido a uma compra"));
            return;
        }
        
        Groceries.Add(grocery);
    }

    public int SetGroceries(IList<Grocery> groceries)
    {
        var groceriesInitialCount = Groceries.Count;
        
        foreach (var grocery in groceries)
        {
            if(!Groceries.Any(x => x.Code.Equals(grocery.Code)))
                Groceries.Add(grocery);
        }

        return Groceries.Count - groceriesInitialCount;
    }
}